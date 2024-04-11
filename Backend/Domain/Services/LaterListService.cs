using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class LaterListService : ILaterListService
    {
        private readonly ILaterListRepository _repository;

        public LaterListService(ILaterListRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
           
        }

        public void Create(LaterList item)
        {
            _repository.Create(item);
        }

        public void Delete(int List_code)
        {
            _repository.Delete(List_code);
        }

        public LaterList? Get(int List_code)
        {
            return _repository.Get(List_code);
        }

        public IEnumerable<LaterList> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int List_code, LaterList item)
        {
            _repository.Set(List_code, item);
        }

        
    }
}