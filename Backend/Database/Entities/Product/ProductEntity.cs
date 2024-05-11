using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SmartTrade.Models;

namespace Backend.Database;

public class ProductEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Product_code { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public string? Features { get; set; }

    public int FingerPrint { get; set; }

    public Category Category { get; set; }
    public List<ListProduct> ListProducts { get; set; }

    public ICollection<GalleryEntity> Gallery { get; set; }

    public ProductEntity()
    {
        ListProducts = new List<ListProduct>();
    }

    public override bool Equals(object? obj)
    {
        return obj is ProductEntity product && this.Product_code == product.Product_code;
    }
    public override int GetHashCode()
    {
        return Product_code.GetHashCode();
    }
}
