using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class LaterList : List
    {
        private readonly IListService<LaterList, string> _service;

        public LaterList(ILaterListService service)
        {
            _service = service;
        }

        public override IEnumerable<Product> GetAll(string email)
        {
            return _service.GetAll(email);
        }

        public override LaterList? GetByEmail(string Email)
        {
            return _service.Get(Email);
        }

        public override void CreateList(string Email)
        {
            _service.Create(Email);
        }

        public override void DeleteList(string Email)
        {
            _service.Delete(Email);
        }

        public override void AddProduct(Product product, string Email)
        {
            _service.AddProduct(product, Email);
        }

        public override void DeleteProduct(Product product, string Email)
        {
            _service.DeleteProduct(product, Email);
        }

    }
}