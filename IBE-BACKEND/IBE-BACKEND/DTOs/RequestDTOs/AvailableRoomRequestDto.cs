using IBE_BACKEND.Utility;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace IBE_BACKEND.DTOs.RequestDTOs
{
    public class AvailableRoomRequestDto
    {
        [Required]
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [Required]
        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [Required]
        [JsonProperty("roomCount")]
        public int RoomCount { get; set; }

        [Required]
        [JsonProperty("propertyId")]
        public int PropertyId { get; set; }

        [JsonProperty("sortType")]
        public SortTypeDto SortType { get; set; }

        [JsonProperty("filterTypes")]
        public FilterTypeDto[] FilterTypes { get; set; }
    }
}
