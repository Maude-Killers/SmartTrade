using Backend.Models;

namespace Backend.Database;

public class TechnoProductEntity : ProductEntity
{
    public TechnoProductEntity() : base()
    {
        Category = Category.Techno;
    }
}