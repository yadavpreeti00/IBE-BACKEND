using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class RoomRatesResponseData
    {
        [JsonProperty("listRoomTypes")]
        public List<RoomType> ListRoomTypes { get; set; }

        public RoomRatesResponseData(List<RoomType> listRoomTypes)
        {
            this.ListRoomTypes = listRoomTypes;
        }
    }
}
