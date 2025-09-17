using System.Collections.ObjectModel;

namespace TestManagment.Domain.Entities
{
    public class TestsScheduling
    {
        public int TestId { get; set; }
        public DateTime DateTime { get; set; }
        public Test test { get; set; }
    }
}
