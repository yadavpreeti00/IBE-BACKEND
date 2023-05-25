using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class RoomTypeResponse
    {
        [JsonProperty("property_id")]
        public int PropertyId { get; set; }

        [JsonProperty("room_type_name")]
        public string RoomTypeName { get; set; }
    }
}
