using Backend.Interfaces;
using Backend.Services;

namespace SmartTrade.Models
{
    public partial class Product
    {
        private readonly IProductService<Product> _service;
        public Product(IProductService<Product> service)
        {
            _service = service;
        }

        public virtual IEnumerable<Product> GetAll()
        {
            return _service.GetAll();
        }

        public virtual Product? GetById(int Product_code)
        {
            return _service.Get(Product_code);
        }

        public IEnumerable<Product> Search(string searchTerm)
        {
            var pservice = _service as ProductService<Product>;
            return pservice.Search(searchTerm);
        }

        public virtual void CreateProduct(Product product)
        { }

        public virtual void EditProduct(int Product_code, Product product)
        { }

        public virtual void DeleteProduct(int Product_code)
        { }
    }
}