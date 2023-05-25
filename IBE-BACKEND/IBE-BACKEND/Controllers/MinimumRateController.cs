using IBE_BACKEND.Services;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("/api")]
    [ApiController]
    public class MinimumRateController : Controller
    {
        private MinimumRateService _minimumRateService;
        public MinimumRateController(MinimumRateService minimumRateService)
        {
            _minimumRateService = minimumRateService;
        }
        [HttpGet]
        [Route("/MinimumRates")]

        public async Task<IActionResult> GetDateToMinimumRateMap()
        {
            var response = await _minimumRateService.GetMinimumRateDateMapping();
            return Ok(response) ;
        }
    }
}
