using MediatR;
using TestManagment.Shared.Dtos;

namespace TestManagment.Domain.Events
{
    public class QuestionsCreatedEvent:INotification
    {
        public List<QuestionCreatedInfo> QuestionsCreatedInfo { get; }
        public QuestionsCreatedEvent(List<QuestionCreatedInfo> questionsCreatedInfo)
        {
            QuestionsCreatedInfo = questionsCreatedInfo;
        }
    }
}
