using MediatR;
using TestManagment.Shared.Dtos;

namespace TestManagment.Domain.Events
{
    public class QuestionCreatedEvent: INotification
    {
        public QuestionCreatedInfo QuestionCreatedInfo { get; }

        public QuestionCreatedEvent(QuestionCreatedInfo questionCreatedInfo)
        {
            QuestionCreatedInfo = questionCreatedInfo;
        }

    }
}
