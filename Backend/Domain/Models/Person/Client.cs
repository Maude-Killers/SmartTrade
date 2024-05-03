namespace SmartTrade.Models
{
    public partial class Client : Person
    {
        public virtual WishList WishList { get; set; }
        public virtual GiftList GiftList { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public Client() : base()
        { }
    }
}