using static System.Net.Mime.MediaTypeNames;

namespace TestManagment.Domain.ValueObjects.Question
{
    public class QuestionChoise
    {
        public string Value { get; }
        public QuestionChoise(string choise)
        {
            if (string.IsNullOrEmpty(choise))
            {
                throw new ArgumentException("The choise text must not be null or empty.");
            }
            Value = choise;
        }
    }
}
