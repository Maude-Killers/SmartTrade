using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class GiftList: List
    {
        [ForeignKey("Client")]
        public string ClientEmail { get; set; }
        public virtual Client Client { get; set; }
        public GiftList() : base()
        {
            Name = "GiftList";
        }
    }
}