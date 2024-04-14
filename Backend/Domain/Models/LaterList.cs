using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class LaterList: List
    {

        public LaterList()
        {
            Name = "LaterList";
        }
    }
}