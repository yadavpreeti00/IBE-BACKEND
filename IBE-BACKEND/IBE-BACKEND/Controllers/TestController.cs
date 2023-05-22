using IBE_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly team03Context _team03Context;
        private readonly ILogger<TestController> _logger;
        public TestController (ILogger<TestController> logger,team03Context team03Context)
        {
            _logger = logger;
            _team03Context = team03Context;
        }


        [HttpGet]
        public IActionResult Test()
        {
           
            return Ok(_team03Context.BookingDetails.ToList());
        }
    }
}
