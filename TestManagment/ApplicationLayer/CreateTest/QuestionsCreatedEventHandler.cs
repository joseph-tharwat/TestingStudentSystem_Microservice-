using MediatR;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure.RabbitMQ;

namespace TestManagment.Services.CreateTest
{
    public class QuestionsCreatedEventHandler : INotificationHandler<QuestionsCreatedEvent>
    {
        private readonly RabbitMqService rabbitMqService;

        public QuestionsCreatedEventHandler(RabbitMqService rabbitMqService)
        {
            this.rabbitMqService = rabbitMqService;
        }


        public async Task Handle(QuestionsCreatedEvent notification, CancellationToken cancellationToken)
        {
            await rabbitMqService.PublishQuestionCreatedAsync(notification, "QuestionsInformation");
        }
    }
}
