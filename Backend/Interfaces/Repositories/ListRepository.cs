using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IListRepository<List, T>
    {
        void AddProduct(Product product, string Email);
        void Create(string Email);
        IEnumerable<List> GetAll();
        List Get(string Email);

        void Delete(string Email);

        void DeleteProduct(Product product, string Email);
    }
}