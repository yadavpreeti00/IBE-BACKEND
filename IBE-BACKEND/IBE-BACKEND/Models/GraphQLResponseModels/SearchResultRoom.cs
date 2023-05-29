using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class SearchResultRoom
    {
        [JsonProperty("room_type")]
        public SearchResultRoomType RoomType { get; set; }
    }
}
