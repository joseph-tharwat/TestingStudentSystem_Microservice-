using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using TestManagment.Shared.Dtos;

namespace TestManagment.Infrastructure.RabbitMQ
{
    public class RabbitMqService
    {
        public async Task sendQuestionToAutoGradeServiceAsync<T>(T objectToSend, string queueName)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://fvthllld:oaAozrlkFX3XlnXZJehtd3UN7oonwZr1@gorilla.lmq.cloudamqp.com/fvthllld") };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: queueName, exclusive: false);

            var msgBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(objectToSend));
            await channel.BasicPublishAsync(exchange: "", routingKey: queueName, msgBody);
        }
    }
}
