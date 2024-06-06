using Backend.Models;

namespace Backend.Domain.DesignPattern
{
    public class TechnoProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new TechnoProduct();
        }
    }

}
