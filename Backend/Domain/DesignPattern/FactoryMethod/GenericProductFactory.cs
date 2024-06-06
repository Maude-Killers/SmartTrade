using Backend.Models;

namespace Backend.Domain.DesignPattern.FactoryMethod
{
    public class GenericProductFactory : ProductFactory
    {
        public override Product CreateProduct()
        {
            return new Product();
        }
    }
}
