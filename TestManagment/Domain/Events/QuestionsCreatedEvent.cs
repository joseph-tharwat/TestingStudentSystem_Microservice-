using MediatR;
using TestManagment.Shared.Dtos;

namespace TestManagment.Domain.Events
{
    public record QuestionsCreatedEvent(List<QuestionCreatedInfo> QuestionsCreatedInfo) :INotification;
}
