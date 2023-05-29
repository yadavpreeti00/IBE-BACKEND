using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class SearchResultsQueryResponse
    {
        [JsonProperty("listRoomAvailabilities")]
        public List<SearchListRoomAvailabilitiesResponse> ListRoomAvailabilities { get;set;}
    }
}
