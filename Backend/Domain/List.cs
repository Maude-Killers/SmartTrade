using Backend.Interfaces;

namespace SmartTrade.Models
{
    public abstract partial class List
    {
        public abstract IEnumerable<List> GetAll();

        public abstract List? GetByEmail(string Email);

        public abstract void CreateList(string Email);

        public abstract void DeleteList(string Email);

        public abstract void DeleteProduct(Product product, string Email);

        public abstract void AddProduct(Product product , string Email);

       
    }
}