namespace SmartTrade.Models
{
    public partial class Client : Person
    {
        public virtual WishList WishList { get; set; }
        public virtual LaterList LaterList { get; set; }
        public Client() : base()
        { }
    }
}