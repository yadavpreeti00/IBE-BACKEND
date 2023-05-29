using System.Text.Json.Serialization;

namespace IBE_BACKEND.DTOs.ResponseDTOs
{
    public class AvailableRoomResponseDto
    {
        [JsonPropertyName("roomTypeName")]
        public string RoomTypeName { get; set; }
        [JsonPropertyName("roomTypeId")]
        public string RoomTypeId { get; set; }
        [JsonPropertyName("singleBed")]
        public int SingleBed { get; set; }
        [JsonPropertyName("doubleBed")]
        public int DoubleBed { get; set; }
        [JsonPropertyName("totalBeds")]
        public int TotalBeds { get; set; }
        [JsonPropertyName("maxCapacity")]
        public int MaxCapacity { get; set; }
        [JsonPropertyName("areaInSquareFeet")]
        public int AreaInSquareFeet { get; set; }
        [JsonPropertyName("specialDeal")]
        public bool SpecialDeal { get; set; }
        [JsonPropertyName("specialDealDescription")]
        public string SpecialDealDescription { get; set; }
        [JsonPropertyName("rate")]
        public double Rate { get; set; }
        [JsonPropertyName("rating")]
        public string Rating { get; set; }
        [JsonPropertyName("reviewers")]
        public long Reviewers { get; set; }

        public AvailableRoomResponseDto(string roomTypeName, string roomTypeId, int singleBed, int doubleBed, int totalBeds, int maxCapacity, int areaInSquareFeet, bool specialDeal, string specialDealDescription, double rate, string rating, long reviewers)
        {
            RoomTypeName = roomTypeName;
            RoomTypeId = roomTypeId;
            SingleBed = singleBed;
            DoubleBed = doubleBed;
            TotalBeds = totalBeds;
            MaxCapacity = maxCapacity;
            AreaInSquareFeet = areaInSquareFeet;
            SpecialDeal = specialDeal;
            SpecialDealDescription = specialDealDescription;
            Rate = rate;
            Rating = rating;
            Reviewers = reviewers;
        }
    }
}
