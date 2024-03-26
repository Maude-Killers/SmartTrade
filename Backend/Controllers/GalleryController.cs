using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly ILogger<GalleryController> _logger;
        private readonly GalleryEntity _domain;

        public GalleryController(GalleryEntity domain, ILogger<GalleryController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetGallery")]
        public IEnumerable<Gallery> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("/galleries/{Product_code}", Name = "GetGalleryByProduct_code")]
        public ActionResult<Gallery> Get(int Product_code)
        {
            var item = _domain.GetByProduct_code(Product_code);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost(Name = "CreateGallery")]
        public void Post(Gallery item)
        {
            _domain.CreateGallery(item);
        }

        [HttpPut("/galleries/{Product_code}", Name = "EditGallery")]
        public void Put(int Product_code, Gallery item)
        {
            _domain.EditGallery(Product_code, item);
        }

        [HttpDelete("/galleries/{Product_code}", Name = "DeleteGallery")]
        public void Delete(int product_code)
        {
            _domain.DeleteGallery(product_code);
        }
    }
}