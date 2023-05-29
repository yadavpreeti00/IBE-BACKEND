using System.Text.Json.Serialization;

namespace IBE_BACKEND.DTOs.ResponseDTOs
{
    public class BookingStatusResponseDto
    {
        [JsonPropertyName("bookingId")]
        public string BookingId { get; set; } = null!;
        [JsonPropertyName("bookingStatus")]
        public bool BookingStatus { get; set; }
    }
}
