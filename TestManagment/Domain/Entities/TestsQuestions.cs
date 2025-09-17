namespace TestManagment.Domain.Entities
{
    public class TestsQuestions
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int Points { get; set; }
        public Question question { get; set; }
        public Test Test { get; set; }
    }
}
