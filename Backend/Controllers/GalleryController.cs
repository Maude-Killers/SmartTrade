using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly ILogger<GalleryController> _logger;
        private readonly Gallery _domain;

        public GalleryController(Gallery domain, ILogger<GalleryController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetGallery")]
        public IEnumerable<Gallery> Get()
        {
            return _domain.GetAll();
        }
        [HttpGet("/galleries/{Product_code}", Name = "GetAllGalleryByProduct_code")]
        public Gallery[] GetAllImages(int Product_code)
        {
            Gallery[] images = _domain.GetAllImages(Product_code);
            return images;
        }

        [HttpPost(Name = "CreateGallery")]
        public void Post(Gallery item)
        {
            _domain.CreateGallery(item);
        }

        [HttpPut("/gallery/{Product_code}", Name = "EditGallery")]
        public void Put(int Product_code, Gallery item)
        {
            _domain.EditGallery(Product_code, item);
        }

        [HttpDelete("/gallery/{Product_code}", Name = "DeleteGallery")]
        public void Delete(int product_code)
        {
            _domain.DeleteGallery(product_code);
        }
    }
}