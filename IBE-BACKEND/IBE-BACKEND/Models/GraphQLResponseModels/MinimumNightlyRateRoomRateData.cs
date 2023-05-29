using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class MinimumNightlyRateRoomRateData
    {
        [JsonProperty("basic_nightly_rate")]
        public double BasicNightlyRate { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
