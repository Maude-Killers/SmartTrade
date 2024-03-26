using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class SalesPerson : Person
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Password { get; set; }
        public string? Company { get; set; }

    }
}