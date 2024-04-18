public class InvalidToken : Exception
{
    public object value { get; }
    public InvalidToken()
    {
    }

    public InvalidToken(string message)
        : base(message)
    {
    }

    public InvalidToken(string message, Exception inner)
        : base(message, inner)
    {
    }

    public InvalidToken(string message, object value): this(message)
    {
        this.value = value;
    }
}