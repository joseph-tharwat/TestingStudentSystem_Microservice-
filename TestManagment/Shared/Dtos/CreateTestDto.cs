namespace TestManagment.Shared.Dtos
{
    public class CreateTestDto
    {
        public string TestTitle { get; set; }
        public List<int> questionsIds {  get; set; }
    }
}
