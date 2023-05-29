using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class ListRoomRate
    {
        [JsonProperty("basic_nightly_rate")]
        public int BasicNightlyRate { get; set; }

        [JsonProperty("room_types")]
        public List<RoomTypesResponse> RoomTypes { get; set; }
    }
}
