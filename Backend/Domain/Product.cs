namespace SmartTrade.Models
{
    public abstract partial class Product
    {
        public abstract IEnumerable<Product> GetAll();

        public abstract Product? GetById(int Product_code);

        public abstract void CreateProduct(Product product);

        public abstract void EditProduct(int Product_code, Product product);

        public abstract void DeleteProduct(int Product_code);
    }
}