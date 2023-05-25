using IBE_BACKEND.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("/api")]
    [ApiController]
    public class SearchResultsController : Controller
    {
        [HttpPost]
        [Route("/SearchResults")]
        public IActionResult GetSearchResult(AvailableRoomRequestDto availableRoomRequest)
        {
            return View();
        }
    }
}
