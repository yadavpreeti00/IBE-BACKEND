using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("/api")]
    [ApiController]
    public class SearchResultsController : Controller
    {
        private readonly IPromotionsService _promotionsService;
        public SearchResultsController (IPromotionsService promotionsService)
        {
            _promotionsService = promotionsService;
        }

        [HttpPost]
        [Route("/SearchResults")]
        public IActionResult GetSearchResult(AvailableRoomRequestDto availableRoomRequest)
        {
            return View();
        }

        [HttpPost]
        [Route("/DefaultPromotions")]
        public async Task<IActionResult> GetDefaultPromotions(PromotionRequestDto promotionRequestDto)
        {
            var response= await _promotionsService.GetDefaultPromotions(promotionRequestDto);
            return Ok(response);
        }

        [HttpPost]
        [Route("/CustomPromotions")]
        public async Task<IActionResult> GetCustomPromotions(PromotionRequestDto promotionRequestDto)
        {
            var response = await _promotionsService.GetCustomPromotion(promotionRequestDto);
            return Ok(response);
        }
    }
}
