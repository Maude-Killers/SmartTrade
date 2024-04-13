namespace SmartTrade.Models
{
    public partial class Product
    {
        public virtual IEnumerable<Product> GetAll() { return null; }

        public virtual Product? GetById(int Product_code) { return null; }

        public virtual void CreateProduct(Product product) { }

        public virtual void EditProduct(int Product_code, Product product) { }

        public virtual void DeleteProduct(int Product_code) { }
    }
}