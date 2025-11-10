using MediatR;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure.RabbitMQ;

namespace TestManagment.ApplicationLayer.CreateQuestion
{
    public class QuestionsCreatedEventHandler : INotificationHandler<ManyQuestionsCreatedEvent>
    {
        private readonly RabbitMqService rabbitMqService;

        public QuestionsCreatedEventHandler(RabbitMqService rabbitMqService)
        {
            this.rabbitMqService = rabbitMqService;
        }


        public async Task Handle(ManyQuestionsCreatedEvent notification, CancellationToken cancellationToken)
        {
            await rabbitMqService.PublishManyQuestionsCreatedAsync(notification);
        }
    }
}
