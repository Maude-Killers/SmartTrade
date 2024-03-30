using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class SportProduct : Product
    {
        private readonly IProductService<SportProduct>? _service;

        public SportProduct(IProductService<SportProduct> service)
        {
            _service = service;
        }

        public override void CreateProduct(Product product)
        {
            _service?.Create((SportProduct)product);
        }

        public override void DeleteProduct(int Product_code)
        {
            _service?.Delete(Product_code);
        }

        public override void EditProduct(int Product_code, Product product)
        {
            _service?.Set(Product_code, (SportProduct)product);
        }

        public override IEnumerable<Product> GetAll()
        {
            return _service?.GetAll() ?? new List<SportProduct>();
        }

        public override Product? GetById(int Product_code)
        {
            return _service?.Get(Product_code);
        }
    }
}