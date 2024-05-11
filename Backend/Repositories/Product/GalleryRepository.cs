using Backend.Database;
using Backend.Interfaces;

namespace Backend.Repositories;
public class GalleryRepository : IGalleryRepository
{
    private readonly AppDbContext _context;

    public GalleryRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(GalleryEntity item)
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

    public GalleryEntity Get(int Product_code)
    {
        var item = _context.Gallery
            .Where(item => item.Product_code == Product_code)
            .FirstOrDefault();

        return item ?? throw new ResourceNotFound("Gallery not found", Product_code);
    }

    public List<GalleryEntity> GetAll()
    {
        return _context.Gallery.ToList();
    }

    public void Set(int Product_code, GalleryEntity item)
    {
        var actualGallery = _context.Gallery
            .Where(item => item.Product_code == Product_code)
            .FirstOrDefault();

        if (actualGallery == null) throw new InvalidOperationException();

        actualGallery.Image = item.Image;
        _context.SaveChanges();
    }
    public IEnumerable<GalleryEntity> GetAllImages(int Product_code)
    {
        return _context.Gallery.Where(item => item.Product_code == Product_code).ToList();
    }

    public List<GalleryEntity> CreateGallery(List<string> images)
    {
        List<GalleryEntity> gallery = new List<GalleryEntity>();
        images.ForEach(image =>
        {
            gallery.Add(new GalleryEntity
            {
                Image = image,
            });
        });
        return gallery;
    }

    public List<string> GetImages(List<GalleryEntity> galleries)
    {
        List<string> images = new List<string>();
        galleries.ForEach(gallery => images.Add(gallery.Image));
        return images;
    }
}