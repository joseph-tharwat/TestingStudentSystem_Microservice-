using System.ComponentModel.DataAnnotations;

namespace TestManagment.Shared.Dtos
{
    public record NextQuestion(int QuestionIndex, string QuestionText, string Choise1, string Choise2, string Choise3);

}
