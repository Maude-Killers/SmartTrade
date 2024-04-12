using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class WishList : List
    {
        private readonly IListService<WishList, string> _service;

        public WishList(IWishListService service)
        {
            _service = service;
        }

        public override IEnumerable<WishList> GetAll()
        {
            return _service.GetAll();
        }

        public override WishList? GetByEmail(string Email)
        {
            return _service.Get(Email);
        }
        
        public override void CreateList(List item)
        {
            _service.Create(item);
        }

        public override void DeleteList(List item)
        {
            _service.Delete(item);
        }

        public override void AddProduct(Product product) 
        { 
            _service.AddProduct(product);
        }

        public override void DeleteProduct(Product product)
        {
            _service.DeleteProduct(product);
        }

    }
}