using IBE_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("api")]
    [ApiController]
    public class ConfigurationDataController : Controller
    {

        private readonly IConfigurationDataService _configurationDataService;
        public ConfigurationDataController(IConfigurationDataService configurationDataService)
        {
            _configurationDataService = configurationDataService;
        }

        [HttpGet]
        [Route("Get/LandingPage")]
        public async Task<IActionResult> GetLandingPageConfiguration()
        {
            var response = await _configurationDataService.GetLandingPageConfigurationData();
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/RoomResultsPage")]
        public async Task<IActionResult> GetRoomResultPageConfiguration()
        {
            var response = await _configurationDataService.GetRoomResultsPageConfigurationData();
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/CheckoutPage")]
        public async Task<IActionResult> GetCheckoutPageConfiguration()
        {
            var response = await _configurationDataService.GetCheckoutPageConfigurationData();
            return Ok(response);
        }
    }
}
