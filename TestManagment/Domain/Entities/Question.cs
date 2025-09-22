using System.Collections.ObjectModel;

namespace TestManagment.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Choise1 { get; set; }
        public string Choise2 { get; set; }
        public string Choise3 { get; set; }
        public string Answer {  get; set; }
        public Collection<TestQuestion> TestQuestions { get; set; }

    }
}
