using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class List
    {
        public enum ListType
        {
            Wish,
            Later
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int List_code { get; set; }

        public string? Name { get; set; }

        public ListType Type { get; set; }

        public List()
        {
        }
    }
}