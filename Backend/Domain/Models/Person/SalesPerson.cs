namespace Backend.Models;
public partial class SalesPerson : Person
{
    public string? Company { get; set; }

    public SalesPerson() : base() { }

}