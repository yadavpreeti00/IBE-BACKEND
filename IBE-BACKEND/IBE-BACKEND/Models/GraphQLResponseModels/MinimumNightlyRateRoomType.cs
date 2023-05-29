using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class MinimumNightlyRateRoomType
    {
        [JsonProperty("room_rates")]
        public List<MinimumNightlyRateRoomRate> RoomRates { get; set; }

        [JsonProperty("property_id")]
        public int PropertyId { get; set; }
    }
}
