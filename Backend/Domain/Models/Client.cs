using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class Client : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string? Password { get; set; }

    }
}