using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Database;

public class ListProduct
{
    [ForeignKey("List")]
    public int List_code { get; set; }
    public ListEntity List { get; set; }

    [ForeignKey("Product")]
    public int Product_code { get; set; }
    public ProductEntity Product { get; set; }
    
    public int Quantity { get; set; } = 1;
    public ListProduct() { }
}