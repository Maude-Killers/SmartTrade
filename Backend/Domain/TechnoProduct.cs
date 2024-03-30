using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class TechnoProduct : Product
    {

        private readonly IProductService<TechnoProduct>? _service;

        public TechnoProduct(IProductService<TechnoProduct> service)
        {
            _service = service;
        }

        public override void CreateProduct(Product product)
        {
            _service?.Create((TechnoProduct)product);
        }

        public override void DeleteProduct(int Product_code)
        {
            _service?.Delete(Product_code);
        }

        public override void EditProduct(int Product_code, Product product)
        {
            _service?.Set(Product_code, (TechnoProduct)product);
        }

        public override IEnumerable<Product> GetAll()
        {
            return _service?.GetAll() ?? new List<TechnoProduct>();
        }

        public override Product? GetById(int Product_code)
        {
            return _service?.Get(Product_code);
        }
    }
}