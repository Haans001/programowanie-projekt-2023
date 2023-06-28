namespace api.Exceptions;

public class QuizIsAlreadyClosed : Exception
{
    public QuizIsAlreadyClosed(string message) : base(message)
    {
    }
}