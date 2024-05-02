using System.ComponentModel.DataAnnotations.Schema;
using SmartTrade.Models;

public class ListProduct
{
    [ForeignKey("List")]
    public int List_code { get; set; }
    public List List { get; set; }

    [ForeignKey("Product")]
    public int Product_code { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; } = 1;
    public ListProduct() {}
}