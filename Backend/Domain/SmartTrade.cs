using Backend.Interfaces;
using Backend.Repositories;
using Backend.Services;

namespace Backend.Models;

public partial class SmartTrade
{
    private readonly IPersonRepository _personRepository;
    private readonly IProductRepository _productRepository;

    public SmartTrade()
    {
        _personRepository = new PersonRepository(AppServices.GetDbContext());
        _productRepository = new ProductRepository(AppServices.GetDbContext());
        Products = _productRepository.GetAll();
        Persons = _personRepository.GetAll();
    }

    public Person LoginPerson(string email, string pass)
    {
        return _personRepository.Get(email, pass);
    }

    public List<Product> GetAllProducts()
    {
        return this.Products;
    }

    public List<Product> GetAllSportProducts()
    {
        return this.Products.Where(p => p.Category == Category.Sport).ToList();
    }

    public List<Product> GetAllTechnoProducts()
    {
        return this.Products.Where(p => p.Category == Category.Techno).ToList();
    }

    public List<Product> GetAllGroceryProducts()
    {
        return this.Products.Where(p => p.Category == Category.Grocery).ToList();
    }

    public Product GetProduct(int productCode)
    {
        return this.Products.Find(product => product.Product_code == productCode) ?? throw new ResourceNotFound("Product not found", productCode);
    }

    public List<Product> SearchProduct(string query)
    {
        return this.Products.Where(product => product.Name.Contains(query) || product.Description.Contains(query)).ToList();
    }

    public void CreateProduct(Product product)
    {
        new ProductService().CreateProduct(product);
    }
}