using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IBE_BACKEND.DTOs.RequestDTOs
{
    public class PromotionRequestDto
    {

        [Required]
        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [Required]
        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("applicable_discount_type")]
        public string? ApplicableDiscountType { get; set; }

        [JsonProperty("room_type")]
        public string? RoomType { get; set; }

        [JsonProperty("promo_code")]
        public string? PromoCode { get; set; }

    }
}
