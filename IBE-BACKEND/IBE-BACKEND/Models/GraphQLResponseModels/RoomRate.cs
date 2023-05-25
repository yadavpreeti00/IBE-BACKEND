using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class RoomRate
    {
        [JsonProperty("room_rate")]
        public RoomRateData RoomRateData { get; set; }

        public RoomRate(RoomRateData roomRate)
        {
            this.RoomRateData = roomRate;
        }
    }
}
