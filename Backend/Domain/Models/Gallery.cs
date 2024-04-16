using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;


namespace SmartTrade.Models
{
    public partial class Gallery
    {
        [Key]
        public string? Image { get; set; }
        [ForeignKey("Product")]
        public int? Product_code { get; set; }
        public virtual Product Product { get; set; }
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