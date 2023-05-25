using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.DTOs.ResponseDTOs;

namespace IBE_BACKEND.Interface
{
    public interface IPromotionsService
    {
        public Task<HashSet<PromotionsResponseDto>> GetDefaultPromotions(PromotionRequestDto promotionRequestBody);

        public Task<PromotionsResponseDto> GetCustomPromotion(PromotionRequestDto promotionRequestDto);
    }
}
