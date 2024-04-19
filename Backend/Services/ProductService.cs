using Backend.Domain.DesignPattern;
using Backend.Domain.DesignPattern.FactoryMethod;
using Backend.Interfaces;
using Backend.Repositories;
using DataTransferObject;
using SmartTrade.Models;

namespace Backend.Services;

public class ProductService
{
    public void CreateProduct(ProductDTO productDTO)
    {
        ProductFactory factory;
        switch (productDTO.Category)
        {
            case "Grocery":
            factory = new GroceryProductFactory();
            break;

            case "Techno":
            factory = new TechnoProductFactory();
            break;

            case "Sport":
            factory = new SportProductFactory();
            break;

            default:
            throw new InvalidOperationException("Unsuported category");
        }

        var newProduct = factory.CreateProduct();
        newProduct.SetName(productDTO.Name);
        newProduct.SetFeatures(productDTO.Features);
        newProduct.SetCategory(productDTO.Category);
        newProduct.SetDescription(productDTO.Description);
        newProduct.SetPrice(productDTO.Price);
        newProduct.SetFingerPrint(productDTO.Huella);
        newProduct.SetImages();
        newProduct.SetRepository(new ProductRepository(AppServices.GetDbContext()));
        newProduct.Save();
    }
}