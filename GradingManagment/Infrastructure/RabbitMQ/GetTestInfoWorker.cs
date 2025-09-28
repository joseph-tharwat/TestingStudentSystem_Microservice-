
using AutoMapper;
using GradingManagment.Domain.Entities;
using GradingManagment.Infrastructure.Database;
using GradingManagment.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Writers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace GradingManagment.Infrastructure.RabbitMQ
{
    public class GetTestInfoWorker : BackgroundService
    {
        private readonly IOptions<RabbitMqSetings> config;
        private readonly IMapper mapper;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IConnection connection;
        private readonly IChannel channel;

        public GetTestInfoWorker(IOptions<RabbitMqSetings> config, IMapper mapper, IServiceScopeFactory serviceScopeFactory)
        {
            this.config = config;
            this.mapper = mapper;
            this.serviceScopeFactory = serviceScopeFactory;
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(config.Value.Uri)
            };
            connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            channel = connection.CreateChannelAsync().GetAwaiter().GetResult();
            channel.QueueDeclareAsync(queue: config.Value.QueueName, exclusive: false).GetAwaiter().GetResult();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += QuestionInfoReceivedAsync;
            await channel.BasicConsumeAsync(queue: config.Value.QueueName, autoAck: true, consumer);
        }

        private async Task QuestionInfoReceivedAsync(object sender, BasicDeliverEventArgs @event)
        {
            var body = @event.Body.ToArray();
            var msg = Encoding.UTF8.GetString(body);

            @event.BasicProperties.Headers.TryGetValue(config.Value.HeaderKey, out var OneOrMany);

            if(OneOrMany is byte[] headerOneManyValue)
            {
                var oneManyStr = Encoding.UTF8.GetString(headerOneManyValue);
                if (oneManyStr == config.Value.HeaderValueOne)
                {
                    await StoreOneQuestionInfo(msg);
                }
                else if (oneManyStr == config.Value.HeaderValueMany)
                {   
                    await StoreManyQuestionInfo(msg);
                }
            }
        }

        private async Task StoreOneQuestionInfo(string Msg)
        {
            using var doc = JsonDocument.Parse(Msg);
            var innerJson = doc.RootElement.GetProperty("QuestionCreatedInfo").GetRawText();

            var questionInfoDto = JsonSerializer.Deserialize<QuestionCreatedInfo>(innerJson);

            var questionInformation = mapper.Map<QuestionInformation>(questionInfoDto);
            using(var scope = serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<GradingDbContext>();
                await dbContext.AddAsync(questionInformation);
                await dbContext.SaveChangesAsync();
            }
        }
        private async Task StoreManyQuestionInfo(string Msg)
        {
            using var doc = JsonDocument.Parse(Msg);
            var innerJson = doc.RootElement.GetProperty("QuestionsCreatedInfo").GetRawText();

            var questionsInfoDto = JsonSerializer.Deserialize<List<QuestionCreatedInfo>>(innerJson);

            var questionsInformations = mapper.Map<List<QuestionInformation>>(questionsInfoDto);

            using(var scope= serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<GradingDbContext>();
                await dbContext.AddRangeAsync(questionsInformations);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
