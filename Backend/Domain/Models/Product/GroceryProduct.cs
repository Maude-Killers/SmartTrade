namespace SmartTrade.Models
{
    public partial class GroceryProduct : Product
    {
        public GroceryProduct() : base()
        {
            Category = SmartTrade.Models.Category.Grocery;
        }
    }
}
