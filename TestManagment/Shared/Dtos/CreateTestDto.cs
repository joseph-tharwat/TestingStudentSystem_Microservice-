using System.ComponentModel.DataAnnotations;

namespace TestManagment.Shared.Dtos
{
    public class CreateTestDto
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Test title can not be empty")]
        public string TestTitle { get; set; }

        [MinLength(1, ErrorMessage = "At least one question id should be provided")]
        public List<int> questionsIds {  get; set; }
    }
}
