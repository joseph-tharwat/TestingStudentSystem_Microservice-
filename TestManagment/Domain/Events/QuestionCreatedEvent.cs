using MediatR;
using TestManagment.Shared.Dtos;

namespace TestManagment.Domain.Events
{
    public record QuestionCreatedEvent(QuestionCreatedInfo QuestionCreatedInfo) : INotification;
}
