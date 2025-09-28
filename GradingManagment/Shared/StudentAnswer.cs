using System.ComponentModel.DataAnnotations;

namespace GradingManagment.Shared
{
    public class StudentAnswer
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
