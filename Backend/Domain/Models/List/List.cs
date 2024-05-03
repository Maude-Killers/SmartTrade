using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrade.Models
{
    public partial class List
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int List_code { get; set; }
        public string? Name { get; set; }
        public List<ListProduct> listProducts{ get; set; }

        public List()
        {
        }
    }
}