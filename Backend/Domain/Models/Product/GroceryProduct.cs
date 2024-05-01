using DataTransferObject;

namespace SmartTrade.Models
{
    public partial class GroceryProduct : Product
    {
        public GroceryProduct() : base()
        {
            Category = Category.Grocery;
        }
    }
}
