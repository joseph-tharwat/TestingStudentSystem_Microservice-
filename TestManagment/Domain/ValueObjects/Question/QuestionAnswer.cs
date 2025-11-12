namespace TestManagment.Domain.ValueObjects.Question
{
    public class QuestionAnswer
    {
        public string Value { get; }

        public QuestionAnswer(string answer ) 
        {
            if (string.IsNullOrEmpty(answer))
            {
                throw new ArgumentException("The answer must not be null or empty.");
            }
            Value = answer;
        }

        public static implicit operator string(QuestionAnswer self) => self.Value;
        public static implicit operator QuestionAnswer(string value)=> new QuestionAnswer(value);
    }
}
