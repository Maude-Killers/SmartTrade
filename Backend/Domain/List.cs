using Backend.Interfaces;

namespace SmartTrade.Models
{
    public abstract partial class List
    {
        public abstract IEnumerable<List> GetAll();

        public abstract List? GetByEmail(string Email);

        public abstract void CreateList(List item);

        public abstract void DeleteList(List item);

        public abstract void DeleteProduct(Product product);

        public abstract void AddProduct(Product product);

       
    }
}