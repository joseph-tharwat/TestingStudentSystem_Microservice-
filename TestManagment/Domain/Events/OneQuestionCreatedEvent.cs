using MediatR;
using TestManagment.Shared.Dtos;

namespace TestManagment.Domain.Events
{
    public record OneQuestionCreatedEvent(QuestionCreatedInfo QuestionCreatedInfo) : INotification;
}
