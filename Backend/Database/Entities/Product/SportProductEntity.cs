using Backend.Models;

namespace Backend.Database;

public class SportProductEntity : ProductEntity
{
    public SportProductEntity() : base()
    {
        Category = Category.Sport;
    }
}