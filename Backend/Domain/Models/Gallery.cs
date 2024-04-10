using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class Gallery
    {
        [Key]
        public string? Image { get; set; }
        [ForeignKey(nameof(Product))]
        public int? Product_code { get; set; }
        public Category? Category_name { get; set; }
        public enum Category
        {
            Techno,
            Grocery,
            Sport
        }
        public Gallery() { }

    }
}