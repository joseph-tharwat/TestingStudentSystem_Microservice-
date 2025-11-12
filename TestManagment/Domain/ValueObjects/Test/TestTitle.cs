namespace TestManagment.Domain.ValueObjects.Test
{
    public class TestTitle
    {
        public string Value { get; }
        public TestTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("The title must not be null or empty.");
            }
            this.Value = title;
        }

        public static implicit operator TestTitle(string title) => new TestTitle(title);
        public static implicit operator string(TestTitle self) => self.Value;
    }
}
