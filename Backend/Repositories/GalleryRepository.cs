using Backend.Interfaces;
using SmartTrade.Models;

namespace Backend.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly AppDbContext _context;

        public GalleryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Gallery item)
        {
            _context.Gallery.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int Product_code)
        {
            var targetGallery = _context.Gallery
                .Where(item => item.Product_code == Product_code)
                .FirstOrDefault();

            if (targetGallery == null) throw new InvalidOperationException();

            _context.Gallery.Remove(targetGallery);
            _context.SaveChanges();
        }

        public Gallery? Get(int Product_code)
        {
            var item = _context.Gallery
                .Where(item => item.Product_code == Product_code)
                .FirstOrDefault();

            return item;
        }

        public IEnumerable<Gallery> GetAll()
        {
            return _context.Gallery.ToList();
        }

        public void Set(int Product_code, Gallery item)
        {
            var actualGallery = _context.Gallery
                .Where(item => item.Product_code == Product_code)
                .FirstOrDefault();

            if (actualGallery == null) throw new InvalidOperationException();

            actualGallery.Image = item.Image; 
            _context.SaveChanges();
        }
        public IEnumerable<Gallery> GetAllImages(int Product_code) 
        {
            return _context.Gallery.Where(item => item.Product_code == Product_code).ToList();
        }
    }
}