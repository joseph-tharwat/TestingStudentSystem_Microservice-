using MediatR;
using TestManagment.Shared.Dtos;

namespace TestManagment.Domain.Events
{
    public record ManyQuestionsCreatedEvent(List<QuestionCreatedInfo> QuestionsCreatedInfo) :INotification;
}
