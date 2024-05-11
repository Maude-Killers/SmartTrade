using Backend.Database;
using SmartTrade.Models;

namespace Backend.Interfaces
{
    public interface IGalleryRepository : EntityRepository<GalleryEntity, int>
    {
        List<GalleryEntity> CreateGallery(List<string> images);
        List<string> GetImages(List<GalleryEntity> galleries);
    }
}