using MediatR;
using TestManagment.ApplicationLayer.CreateQuestion.Interfaces;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure.RabbitMQ;

namespace TestManagment.ApplicationLayer.CreateQuestion
{
    public class QuestionsCreatedEventHandler : INotificationHandler<ManyQuestionsCreatedEvent>
    {
        private readonly IEventPublisher eventPublisher;

        public QuestionsCreatedEventHandler(IEventPublisher eventPublisher)
        {
            this.eventPublisher = eventPublisher;
        }


        public async Task Handle(ManyQuestionsCreatedEvent notification, CancellationToken cancellationToken)
        {
            await eventPublisher.PublishManyQuestionsCreatedAsync(notification);
        }
    }
}
