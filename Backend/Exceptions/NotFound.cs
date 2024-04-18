public class ResourceNotFound : Exception
{
    public object value { get; }

    public ResourceNotFound()
    {
    }

    public ResourceNotFound(string message)
        : base(message)
    {
    }

    public ResourceNotFound(string message, Exception inner)
        : base(message, inner)
    {
    }

    public ResourceNotFound(string message, object value)
        : this(message)
    {
        this.value = value;
    }
}