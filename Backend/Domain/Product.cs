using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class ProductEntity
    {
        private readonly IProductService _service;

        public ProductEntity(IProductService service)
        {
            _service = service;
        }

        public IEnumerable<Product> GetAll()
        {
            return _service.GetAll();
        }

        public Product? GetById(int Product_code)
        {
            return _service.Get(Product_code);
        }

        public void CreateProduct(Product product)
        {
            _service.Create(product);
        }

        public void EditProduct(int Product_code, Product product)
        {
            _service.Set(Product_code, product);
        }

        public void DeleteProduct(int Product_code)
        {
            _service.Delete(Product_code);
        }
    }
}