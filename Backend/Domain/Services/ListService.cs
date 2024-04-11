using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class ListService : IListService
    {
        private readonly IListRepository _repository;

        public ListService(IListRepository repository)
        {
            _repository = repository;
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