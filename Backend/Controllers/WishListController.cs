using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishListController : ControllerBase
    {
        private readonly ILogger<WishListController> _logger;
        private readonly WishListEntity _domain;

        public WishListController(WishListEntity domain, ILogger<WishListController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetWishList")]
        public IEnumerable<WishList> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("/WishLists/{List_code}", Name = "GetWishListByList_code")]
        public ActionResult<WishList> Get(int List_code)
        {
            var item = _domain.GetByList_code(List_code);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost(Name = "CreateWishList")]
        public void Post(WishList item)
        {
            _domain.CreateWishList(item);
        }

        [HttpPut("/galleries/{List_code}", Name = "EditWishList")]
        public void Put(int List_code, WishList item)
        {
            _domain.EditWishList(List_code, item);
        }

        [HttpDelete("/galleries/{List_code}", Name = "DeleteWishList")]
        public void Delete(int List_code)
        {
            _domain.DeleteWishList(List_code);
        }
    }
}