using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class LaterList: List
    {
        [ForeignKey("Client")]
        public string ClientEmail { get; set; }
        public virtual Client Client { get; set; }
        public LaterList()
        {
            Name = "LaterList";
        }
    }
}