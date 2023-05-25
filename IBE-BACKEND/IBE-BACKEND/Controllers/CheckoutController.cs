using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("api")]
    [ApiController]
    public class CheckoutController : Controller
    {
        [HttpGet]
        [Route("Get/PriceBreakDown")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
