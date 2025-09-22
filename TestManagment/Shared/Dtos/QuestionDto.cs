using System.ComponentModel.DataAnnotations;

namespace TestManagment.Shared.Dtos
{
    public class QuestionDto
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Question text is required")]
        public string QuestionText { get; set; }
        public string Choise1 { get; set; }
        public string Choise2 { get; set; }
        public string Choise3 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Question answer is required")]
        public string Answer { get; set; }
    }
}
