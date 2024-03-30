using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class Gallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey(nameof(Product))]
        public int Product_code { get; set; }

        public string? Image { get; set; }
    }
}