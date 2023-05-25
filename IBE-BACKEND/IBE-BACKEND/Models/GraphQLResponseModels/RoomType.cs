﻿using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class RoomType
    {
        [JsonProperty("room_type_name")]
        public string RoomTypeName { get; set; }
        [JsonProperty("room_rates")]
        public List<RoomRate> RoomRates { get; set; }

        public RoomType(string roomTypeName, List<RoomRate> roomRates)
        {
            this.RoomTypeName = roomTypeName;
            this.RoomRates = roomRates;
        }
    }
}
