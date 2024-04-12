using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class ListService : IListService<List>
    {
        private readonly IListRepository<List> _repository;

        public ListService(IListRepository<List> repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void Create(List item)
        {
            _repository.Create(item);
        }

        public void Delete(int List_code)
        {
            _repository.Delete(List_code);
        }

        public List? Get(int List_code)
        {
            return _repository.Get(List_code);
        }

        public IEnumerable<List> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int List_code, List item)
        {
            _repository.Set(List_code, item);
        }
    }
}