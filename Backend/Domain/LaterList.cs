using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class LaterList
    {
        private readonly ILaterListService _service;

        public LaterList(ILaterListService service)
        {
            _service = service;
        }

        public IEnumerable<LaterList> GetAll()
        {
            return _service.GetAll();
        }

        public LaterList? GetByList_code(int List_code)
        {
            return _service.Get(List_code);
        }

        public void CreateLaterList(LaterList item)
        {
            _service.Create(item);
        }

        public void EditLaterList(int List_code, LaterList item)
        {
            _service.Set(List_code, item);
        }

        public void DeleteLaterList(int List_code)
        {
            _service.Delete(List_code);
        }

        public void AddProduct(Product product) 
        { 
            _service.AddProduct(product);
        }
       
    }
}