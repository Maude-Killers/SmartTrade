namespace Backend.Database;

public class ClientEntity
{
    public virtual WishListEntity WishList { get; set; }
    public virtual GiftListEntity GiftList { get; set; }
    public virtual ShoppingCartEntity ShoppingCart { get; set; }
    public virtual LaterListEntity LaterList { get; set; }
    public ClientEntity() : base()
    { }
}