namespace Backend.Models;
public partial class GroceryProduct : Product
{
    public GroceryProduct() : base()
    {
        Category = Category.Grocery;
    }
}