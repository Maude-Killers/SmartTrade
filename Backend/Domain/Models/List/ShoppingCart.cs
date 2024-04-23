using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrade.Models
{
    public partial class ShoppingCart : List
    {
        [ForeignKey("Client")]
        public string ClientEmail { get; set; }
        public virtual Client Client { get; set; }

        public ShoppingCart() : base()
        {
            Name = "ShoppingCart";
        }
    }
}