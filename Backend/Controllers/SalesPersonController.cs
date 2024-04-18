using Microsoft.AspNetCore.Mvc;
using SmartTrade.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("salesperson")]
    public class SalesPersonController : ControllerBase
    {

        private readonly ILogger<SalesPersonController> _logger;

        public SalesPersonController(ILogger<SalesPersonController> logger)
        {
            _logger = logger;
        }
    }
}