namespace TestManagment.Domain.Entities
{
    public class TestQuestion
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public Question question { get; set; }
        public Test Test { get; set; }
        public TestQuestion() { }
        public TestQuestion(int testId, int questionId) 
        { 
            TestId = testId;
            QuestionId = questionId;
        }
    }
}
