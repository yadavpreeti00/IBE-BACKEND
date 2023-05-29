using com.sun.istack.@internal;
using java.lang;
using Newtonsoft.Json;

namespace IBE_BACKEND.DTOs.RequestDTOs
{
    public class PriceBreakdownRequestDto
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }
        [JsonProperty("endDate")]
        public string EndDate { get; set; }
        [JsonProperty("roomCount")]
        public int RoomCount { get; set; }
        [JsonProperty("propertyId")]
        public int PropertyId { get; set; }
        [JsonProperty("roomType")]
        public string RoomType { get; set; }
    }
        
}
