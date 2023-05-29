using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class SearchListRoomAvailabilitiesResponse
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("room_id")]
        public int RoomId { get; set; }

        [JsonProperty("room")]
        public SearchResultRoom Room { get; set; }
    }
}
