using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [Route("api")]
    [ApiController]
    public class SearchResultsController : Controller
    {
        private readonly IPromotionsService _promotionsService;
        private readonly ISearchResultsService _searchResultsService;
        public SearchResultsController (IPromotionsService promotionsService, ISearchResultsService searchResultsService)
        {
            _promotionsService = promotionsService;
            _searchResultsService = searchResultsService;
        }

        [HttpPost]
        [Route("/SearchResults")]
        public async Task<IActionResult> GetSearchResult(AvailableRoomRequestDto availableRoomRequest)
        {
            var response = await _searchResultsService.GetSearchResults(availableRoomRequest);
            return Ok(response);
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
