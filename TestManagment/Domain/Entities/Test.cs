using System.Collections.ObjectModel;

namespace TestManagment.Domain.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<TestQuestion> TestQuestions { get; set; }  
        public Collection<TestsScheduling> Schedulings { get; set; }
    }
}
