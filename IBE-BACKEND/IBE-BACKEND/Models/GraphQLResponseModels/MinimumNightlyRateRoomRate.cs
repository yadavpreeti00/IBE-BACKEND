using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class MinimumNightlyRateRoomRate
    {
        [JsonProperty("room_rate")]
        public MinimumNightlyRateRoomRateData RoomRate { get; set; }
    }
}
