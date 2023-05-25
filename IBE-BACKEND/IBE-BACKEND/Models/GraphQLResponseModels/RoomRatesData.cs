using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class RoomRatesData
    {
        [JsonProperty("listRoomTypes")]
        public List<RoomType> ListRoomTypes { get; set; }

        public RoomRatesData(List<RoomType> listRoomTypes)
        {
            this.ListRoomTypes = listRoomTypes;
        }
    }
}
