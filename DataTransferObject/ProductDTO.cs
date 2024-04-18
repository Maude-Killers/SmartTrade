namespace DataTransferObject;
public class ProductDTO
{
    public int? Product_code { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public string? Features { get; set; }

    public int Huella { get; set; }

    public string Category { get; set; }


}