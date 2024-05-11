namespace Backend.Database;

public class SalesPersonEntity : PersonEntity
{
    public string? Company { get; set; }

    public SalesPersonEntity() : base() { }
}