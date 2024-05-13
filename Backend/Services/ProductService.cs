using Backend.Domain.DesignPattern;
using Backend.Domain.DesignPattern.FactoryMethod;
using Backend.Repositories;
using Backend.Models;

namespace Backend.Services;

public class ProductService
{
    public void CreateProduct(Product product)
    {
        ProductFactory factory;
        switch (product.Category)
        {
            case Category.Grocery:
            factory = new GroceryProductFactory();
            break;

            case Category.Techno:
            factory = new TechnoProductFactory();
            break;

            case Category.Sport:
            factory = new SportProductFactory();
            break;

            default:
            throw new InvalidOperationException("Unsuported category");
        }

        var newProduct = factory.CreateProduct();
        newProduct.SetName(product.Name);
        newProduct.SetFeatures(product.Features);
        newProduct.SetCategory(product.Category);
        newProduct.SetDescription(product.Description);
        newProduct.SetPrice(product.Price);
        newProduct.SetFingerPrint(product.FingerPrint);
        newProduct.SetImages(product.Images);
        newProduct.SetRepository(new ProductRepository(AppServices.GetDbContext()));
        newProduct.Save();
    }
}