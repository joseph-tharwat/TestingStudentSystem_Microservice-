using TestManagment.Domain.Events;

namespace TestManagment.ApplicationLayer.CreateQuestion.Interfaces
{
    public interface IEventPublisher
    {
        public Task PublishOneQuestionCreatedAsync(OneQuestionCreatedEvent question);
        public Task PublishManyQuestionsCreatedAsync(ManyQuestionsCreatedEvent questions);

    }
}
