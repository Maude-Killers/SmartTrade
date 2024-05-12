namespace Backend.Models;

public partial class Product
{
    public int Product_code { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public string? Features { get; set; }

    public int FingerPrint { get; set; }

    public Category Category { get; set; }

    public List<string> Images { get; set; }

    public Product()
    { }

    public override bool Equals(object? obj)
    {
        return obj is Product product && this.Product_code == product.Product_code;
    }
    public override int GetHashCode()
    {
        return Product_code.GetHashCode();
    }
}

public enum Category
{
    Techno,
    Grocery,
    Sport
}