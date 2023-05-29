using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("api")]
    [ApiController]
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;
        public CheckoutController(ICheckoutService checkoutService) 
        {
            _checkoutService = checkoutService;
        }
        [HttpPost]
        [Route("Get/PriceBreakDown")]
        public async Task<IActionResult> GetRateBreakDown(PriceBreakdownRequestDto priceBreakdownRequest)
        {
            var response = await _checkoutService.GetPriceBreakDown(priceBreakdownRequest);
            return Ok(response);
            
        }
    }
}
