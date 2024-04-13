namespace SmartTrade.Models
{
    public partial class Client : Person
    {
        public WishList wishList { get; set; }
        public Client() : base()
        {
 
        }
    }
}