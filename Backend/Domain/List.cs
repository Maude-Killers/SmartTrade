using Backend.Interfaces;

namespace SmartTrade.Models
{
    public abstract partial class List
    {
        public abstract IEnumerable<List> GetAll();

        public abstract List? GetByEmail(string Email);

        public abstract void CreateList(string Email);

        public abstract void EditList(int List_code, List item);

        public abstract void DeleteList(int List_code);

        public abstract void AddProduct(Product product);
       
    }
}