using Azure.Core;
using MediatR;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure.RabbitMQ;

namespace TestManagment.Services.CreateTest
{
    public class QuestionCreatedEventHandler : INotificationHandler<QuestionCreatedEvent>
    {
        private readonly RabbitMqService rabbitMqService;
        public QuestionCreatedEventHandler(RabbitMqService _rabbitMqService)
        {
            rabbitMqService = _rabbitMqService;
        }

        public async Task Handle(QuestionCreatedEvent notification, CancellationToken cancellationToken)
        {
            await rabbitMqService.PublishQuestionCreatedAsync(notification, "QuestionInformation");
        }

    }
}
