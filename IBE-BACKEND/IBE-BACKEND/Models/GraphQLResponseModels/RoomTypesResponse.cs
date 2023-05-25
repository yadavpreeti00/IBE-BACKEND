using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class RoomTypesResponse
    {
        [JsonProperty("room_rate")]
        public RoomTypeResponse RoomType { get; set; }
    }
}
