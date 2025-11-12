namespace TestManagment.Domain.ValueObjects.Question
{
    public class QuestionTxt
    {
        public string Value { get; }

        public QuestionTxt(string txt)
        {
            if(string.IsNullOrEmpty(txt))
            {
                throw new ArgumentException("The question text must not be null or empty.");
            }
            Value= txt;
        }

        public static implicit operator QuestionTxt(string txt)
        {
            return new QuestionTxt(txt);
        }

        public static implicit operator string(QuestionTxt self)
        {
            return self.Value;
        }
    }
}
