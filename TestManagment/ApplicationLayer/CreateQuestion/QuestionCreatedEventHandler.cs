using Azure.Core;
using MediatR;
using TestManagment.ApplicationLayer.CreateQuestion.Interfaces;
using TestManagment.Domain.Events;
using TestManagment.Infrastructure.RabbitMQ;

namespace TestManagment.ApplicationLayer.CreateQuestion
{
    public class QuestionCreatedEventHandler : INotificationHandler<OneQuestionCreatedEvent>
    {
        private readonly IEventPublisher eventPublisher;
        public QuestionCreatedEventHandler(IEventPublisher eventPublisher)
        {
            this.eventPublisher = eventPublisher;
        }

        public async Task Handle(OneQuestionCreatedEvent notification, CancellationToken cancellationToken)
        {
            await eventPublisher.PublishOneQuestionCreatedAsync(notification);
        }

    }
}
