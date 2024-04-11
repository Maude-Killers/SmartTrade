using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class ListEntity
    {
        private readonly IListService _service;

        public ListEntity(IListService service)
        {
            _service = service;
        }

        public IEnumerable<List> GetAll()
        {
            return _service.GetAll();
        }

        public List? GetByList_code(int List_code)
        {
            return _service.Get(List_code);
        }

        public void CreateList(List item)
        {
            _service.Create(item);
        }

        public void EditList(int List_code, List item)
        {
            _service.Set(List_code, item);
        }

        public void DeleteList(int List_code)
        {
            _service.Delete(List_code);
        }
    }
}