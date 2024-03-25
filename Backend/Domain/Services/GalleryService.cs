using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IGalleryRepository _repository;

        public GalleryService(IGalleryRepository repository)
        {
            _repository = repository;
        }

        public void Create(Gallery item)
        {
            _repository.Create(item);
        }

        public void Delete(int Product_code)
        {
            _repository.Delete(Product_code);
        }

        public Gallery? Get(int Product_code)
        {
            return _repository.Get(Product_code);
        }

        public IEnumerable<Gallery> GetAll()
        {
            return _repository.GetAll();
        }

        public void Set(int Product_code, Gallery item)
        {
            _repository.Set(Product_code, item);
        }
    }
}