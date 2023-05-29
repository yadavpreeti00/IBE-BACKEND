using System.Text.Json.Serialization;

namespace IBE_BACKEND.DTOs.ResponseDTOs
{
    public class QueueBookingResponseDto
    {
        [JsonPropertyName("bookingId")]
        public string BookingId { get; set; }
    }
}
