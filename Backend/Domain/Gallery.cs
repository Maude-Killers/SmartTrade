using Backend.Interfaces;

namespace SmartTrade.Models
{
    public partial class GalleryEntity
    {
        private readonly IGalleryService _service;

        public GalleryEntity(IGalleryService service)
        {
            _service = service;
        }

        public IEnumerable<Gallery> GetAll()
        {
            return _service.GetAll();
        }

        public Gallery? GetByProduct_code(int Product_code)
        {
            return _service.Get(Product_code);
        }

        public void CreateGallery(Gallery item)
        {
            _service.Create(item);
        }

        public void EditGallery(int Product_code, Gallery item)
        {
            _service.Set(Product_code, item);
        }

        public void DeleteGallery(int Product_code)
        {
            _service.Delete(Product_code);
        }
    }
}