public class InvalidScoreFormatException : Exception
{
    public InvalidScoreFormatException() : base("Score is not a valid integer") { }
    public InvalidScoreFormatException(string message) : base(message) { }
    public InvalidScoreFormatException(string message, Exception inner) : base(message, inner) { }
}

public class MissingFieldException : Exception
{
    public MissingFieldException() : base("Missing required field in student record") { }
    public MissingFieldException(string message) : base(message) { }
    public MissingFieldException(string message, Exception inner) : base(message, inner) { }
}
