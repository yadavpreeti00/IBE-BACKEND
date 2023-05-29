using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class SearchRoomRatesQueryResponse
    {
        [JsonProperty("listRoomRates")]
        public List<ListRoomRate> ListRoomTypes { get; set; }
    }
}
