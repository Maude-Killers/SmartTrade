namespace SmartTrade.Models
{
    public partial class GroceryProduct : Product
    {
        public string? Category { get; set; }

        public GroceryProduct() : base()
        {
        }
    }
}
