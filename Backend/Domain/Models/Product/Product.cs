using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

        public int? Huella { get; set; }

        public string? Category { get; set; }
        public List<ListProduct> ListProducts { get; set; }

        public ICollection<Gallery> Images { get; set; }

        public Product()
        {
            ListProducts = new List<ListProduct>();
        }
    }
}