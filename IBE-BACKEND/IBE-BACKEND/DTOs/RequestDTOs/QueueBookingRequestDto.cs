using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IBE_BACKEND.DTOs.RequestDTOs
{
    public class QueueBookingRequestDto
    {
        [JsonProperty("bookingId")]
        [JsonPropertyName("bookingId")]
        public string? bookingId { get; set; }

        [JsonPropertyName("send_special_offer")]
        [JsonProperty("send_special_offer")]
        public bool send_special_offer { get; set; }

        [JsonPropertyName("first_name")]
        [JsonProperty("first_name")]
        public string first_name { get; set; }

        [JsonPropertyName("last_name")]
        [JsonProperty("last_name")]
        public string last_name { get; set; }

        [JsonPropertyName("phone")]
        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonPropertyName("email")]
        [JsonProperty("email")]
        public string email { get; set; }

        [JsonPropertyName("card_number")]
        [JsonProperty("card_number")]
        public string card_number { get; set; }
        [JsonPropertyName("property_id")]
        [JsonProperty("property_id")]

        public string property_id { get; set; }
        [JsonPropertyName("check_in_date")]
        [JsonProperty("check_in_date")]

        public string check_in_date { get; set; }
        [JsonPropertyName("check_out_date")]
        [JsonProperty("check_out_date")]
        public string check_out_date { get; set; }

        [JsonPropertyName("guests")]
        [JsonProperty("guests")]
        public string guests { get; set; }

        [JsonPropertyName("promo_title")]
        [JsonProperty("promo_title")]
        public string? promo_title { get; set; }

        [JsonPropertyName("promo_description")]
        [JsonProperty("promo_description")]
        public string? promo_description { get; set; }

        [JsonPropertyName("subtotal")]
        [JsonProperty("subtotal")]
        public string subtotal { get; set; }

        [JsonPropertyName("taxes")]
        [JsonProperty("taxes")]
        public string taxes { get; set; }

        [JsonPropertyName("vat")]
        [JsonProperty("vat")]
        public string vat { get; set; }

        [JsonPropertyName("total_for_stay")]
        [JsonProperty("total_for_stay")]
        public string total_for_stay { get; set; }

        [JsonPropertyName("room_type")]
        [JsonProperty("room_type")]
        public string room_type { get; set; }

        [JsonPropertyName("mailing_address1")]
        [JsonProperty("mailing_address1")]
        public string mailing_address1 { get; set; }

        [JsonPropertyName("mailing_address2")]
        [JsonProperty("mailing_address2")]
        public string? mailing_address2 { get; set; }

        [JsonPropertyName("country")]
        [JsonProperty("country")]
        public string country { get; set; }

        [JsonPropertyName("state")]
        [JsonProperty("state")]
        public string state { get; set; }

        [JsonPropertyName("city")]
        [JsonProperty("city")]
        public string city { get; set; }

        [JsonPropertyName("zip")]
        [JsonProperty("zip")]
        public string zip { get; set; }

        [JsonPropertyName("room_count")]
        [JsonProperty("room_count")]
        public string room_count { get; set; }
    }


}
