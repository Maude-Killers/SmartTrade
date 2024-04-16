using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class GroceryProduct : Product
    {
        private readonly IProductService<GroceryProduct>? _service;

        public GroceryProduct(IProductService<GroceryProduct> service)
        {
            _service = service;
        }

        public override void CreateProduct(Product product)
        {
            _service?.Create((GroceryProduct)product);
        }

        public override void DeleteProduct(int Product_code)
        {
            _service?.Delete(Product_code);
        }

        public override void EditProduct(int Product_code, Product product)
        {
            _service?.Set(Product_code, (GroceryProduct)product);
        }

        public override IEnumerable<Product> GetAll()
        {
            return _service?.GetAll() ?? new List<GroceryProduct>();
        }

        public override Product? GetById(int Product_code)
        {
            return _service?.Get(Product_code);
        }
    }
}