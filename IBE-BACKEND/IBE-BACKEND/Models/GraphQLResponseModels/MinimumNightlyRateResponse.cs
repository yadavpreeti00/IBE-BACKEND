using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class MinimumNightlyRateResponse
    {
        [JsonProperty("listRoomTypes")]
        public List<MinimumNightlyRateRoomType> ListRoomTypes { get; set; }
    }
}
