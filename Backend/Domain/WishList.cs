using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class WishList
    {
        private readonly IWishListService _service;

        public WishList(IWishListService service)
        {
            _service = service;
        }

        public IEnumerable<WishList> GetAll()
        {
            return _service.GetAll();
        }

        public WishList? GetByList_code(int List_code)
        {
            return _service.Get(List_code);
        }

        public void CreateWishList(WishList item)
        {
            _service.Create(item);
        }

        public void EditWishList(int List_code, WishList item)
        {
            _service.Set(List_code, item);
        }

        public void DeleteWishList(int List_code)
        {
            _service.Delete(List_code);
        }

        public void AddProduct(Product product) 
        { 
            _service.AddProduct(product);
        }
       
    }
}