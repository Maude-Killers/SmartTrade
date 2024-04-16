using Backend.Interfaces;
using Backend.Services;

namespace SmartTrade.Models
{
    public partial class Gallery
    {
        private readonly IGalleryService _service;

        public Gallery(IGalleryService service)
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
        public Gallery[] GetAllImages(int Product_code) 
        {
            GalleryService galleryService = _service as GalleryService;
            Gallery[] galleries = galleryService.GetAllImages(Product_code);
            return galleries;
        }
    }
}