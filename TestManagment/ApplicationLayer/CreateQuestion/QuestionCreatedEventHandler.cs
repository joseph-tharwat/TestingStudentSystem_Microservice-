using Azure.Core;
using MediatR;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure.RabbitMQ;

namespace TestManagment.ApplicationLayer.CreateQuestion
{
    public class QuestionCreatedEventHandler : INotificationHandler<OneQuestionCreatedEvent>
    {
        private readonly RabbitMqService rabbitMqService;
        public QuestionCreatedEventHandler(RabbitMqService _rabbitMqService)
        {
            rabbitMqService = _rabbitMqService;
        }

        public async Task Handle(OneQuestionCreatedEvent notification, CancellationToken cancellationToken)
        {
            await rabbitMqService.PublishOneQuestionCreatedAsync(notification);
        }

    }
}
