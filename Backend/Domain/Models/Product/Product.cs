using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataTransferObject;

namespace SmartTrade.Models
{
    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_code { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string? Features { get; set; }

        public int Huella { get; set; }

        public Category Category { get; set; }
        public List<ListProduct> ListProducts { get; set; }

        public ICollection<Gallery> Images { get; set; }

        public Product()
        {
            ListProducts = new List<ListProduct>();
        }

        public override bool Equals(object? obj)
        {
            return obj is Product product && this.Product_code == product.Product_code;
        }
        public override int GetHashCode()
        {
            return Product_code.GetHashCode();
        }
    }
}