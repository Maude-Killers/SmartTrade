using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class WishList: List
    {

        public WishList()
        {
            Name = "WishList";
        }
    }
}