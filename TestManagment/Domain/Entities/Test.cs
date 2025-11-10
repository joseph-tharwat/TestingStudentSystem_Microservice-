using System.Collections.ObjectModel;

namespace TestManagment.Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsPublished { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }  
        public Collection<TestsScheduling> Schedulings { get; set; }

        public void AddQuestion(int questionId)
        {
            if(IsPublished)
            {
                throw new InvalidOperationException("The test has been published, You can not add any questions now.");
            }

            if(TestQuestions.Any(q=>q.QuestionId == questionId))
            {
                throw new InvalidOperationException("The question is already added before");
            }
            TestQuestions.Add(new TestQuestion(Id, questionId));
        }

        public void RemoveQuestion(int questionId)
        {
            if (IsPublished)
            {
                throw new InvalidOperationException("The test has been published, You can not remove any questions now.");
            }

            var testQuestion = TestQuestions.FirstOrDefault(q => q.QuestionId == questionId);
            if (testQuestion == null)
            {
                throw new InvalidOperationException("The question is not in the test");
            }
            TestQuestions.Remove(testQuestion);
        }

        
    }
}
