using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrade.Models
{
    public partial class WishList : List
    {
        [ForeignKey("Client")]
        public string ClientEmail { get; set; }
        public virtual Client Client { get; set; }

        public WishList() : base()
        {
            Name = "WishList";
        }
    }
}