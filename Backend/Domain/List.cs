namespace SmartTrade.Models
{
    public abstract partial class List
    {
        public abstract IEnumerable<Product> GetAll(string email);

        public abstract List? GetByEmail(string email);

        public abstract void CreateList(string email);

        public abstract void DeleteList(string email);

        public abstract void DeleteProduct(Product product, string email);

        public abstract void AddProduct(Product product , string email);

       
    }
}