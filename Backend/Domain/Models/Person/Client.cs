namespace SmartTrade.Models;
public partial class Client : Person
{
    public virtual List<Product> WishList { get; set; }
    public virtual List<Product> GiftList { get; set; }
    public virtual List<Product> ShoppingCart { get; set; }
    public virtual List<Product> LaterList { get; set; }
    public Client() : base()
    { }
}