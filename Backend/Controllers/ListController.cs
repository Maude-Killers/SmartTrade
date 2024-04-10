using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : ControllerBase
    {
        private readonly ILogger<ListController> _logger;
        private readonly ListEntity _domain;

        public ListController(ListEntity domain, ILogger<ListController> logger)
        {
            _logger = logger;
            _domain = domain;
        }

        [HttpGet(Name = "GetList")]
        public IEnumerable<List> Get()
        {
            return _domain.GetAll();
        }

        [HttpGet("/lists/{List_code}", Name = "GetListByList_code")]
        public ActionResult<List> Get(int List_code)
        {
            var item = _domain.GetByList_code(List_code);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost(Name = "CreateList")]
        public void Post(List item)
        {
            _domain.CreateList(item);
        }

        [HttpPut("/galleries/{List_code}", Name = "EditList")]
        public void Put(int List_code, List item)
        {
            _domain.EditList(List_code, item);
        }

        [HttpDelete("/galleries/{List_code}", Name = "DeleteList")]
        public void Delete(int List_code)
        {
            _domain.DeleteList(List_code);
        }
    }
}