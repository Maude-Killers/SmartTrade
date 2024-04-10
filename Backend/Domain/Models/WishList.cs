using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartTrade.Models
{
    public partial class WishList: List
    {
        public List<Product> Products { get; set; }



        public WishList()
        {
        }
    }
}