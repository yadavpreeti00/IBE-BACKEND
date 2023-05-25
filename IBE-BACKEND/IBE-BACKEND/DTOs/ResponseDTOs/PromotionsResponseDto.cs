using IBE_BACKEND.Models.GraphQLResponseModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IBE_BACKEND.DTOs.ResponseDTOs
{
    public class PromotionsResponseDto
    {

        [JsonProperty("promoCode")]
        public string? PromoCode { get; set; }

        [JsonProperty("isDeactivated")]
        [Required]
        public bool IsDeactivated { get; set; }

        [JsonProperty("minimumDaysOfStay")]
        [Required]
        public int MinimumDaysOfStay { get; set; }

        [JsonProperty("priceFactor")]
        [Required]
        public float PriceFactor { get; set; }

        [JsonProperty("promotionDescription")]
        [Required]
        public string PromotionDescription { get; set; }

        [JsonProperty("promotionTitle")]
        [Required]
        public string PromotionTitle { get; set; }

        [JsonProperty("promotionId")]
        [Required]
        public int PromotionId { get; set; }

        public PromotionsResponseDto(string? promoCode, bool isDeactivated, int minimumDaysOfStay, float priceFactor, string promotionDescription, string promotionTitle, int promotionId)
        {
            PromoCode = promoCode;
            IsDeactivated = isDeactivated;
            MinimumDaysOfStay = minimumDaysOfStay;
            PriceFactor = priceFactor;
            PromotionDescription = promotionDescription;
            PromotionTitle = promotionTitle;
            PromotionId = promotionId;
        }

    }
}
