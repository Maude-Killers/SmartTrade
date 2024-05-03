using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataTransferObject;

namespace SmartTrade.Models
{
    public partial class Gallery
    {
        [Key]
        public string? Image { get; set; }
        [ForeignKey("Product")]
        public int? Product_code { get; set; }
        public virtual Product Product { get; set; }
        public Category? Category { get; set; }
        public Gallery() { }

    }
}