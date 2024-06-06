using Backend.Models;

namespace Backend.Database;

public class GroceryProductEntity : ProductEntity
{
    public GroceryProductEntity() : base()
    {
        Category = Category.Grocery;
    }
}