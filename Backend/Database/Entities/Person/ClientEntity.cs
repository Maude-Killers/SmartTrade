namespace Backend.Database;

public class ClientEntity : PersonEntity
{
    public virtual WishListEntity WishList { get; set; } = new WishListEntity();
    public virtual GiftListEntity GiftList { get; set; } = new GiftListEntity();
    public virtual ShoppingCartEntity ShoppingCart { get; set; } = new ShoppingCartEntity();
    public virtual LaterListEntity LaterList { get; set; } = new LaterListEntity();
    public ClientEntity() : base()
    { }
}