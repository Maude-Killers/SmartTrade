namespace Backend.Models;

public partial class TechnoProduct : Product
{
    public TechnoProduct() : base()
    {
        Category = Category.Techno;
    }
}