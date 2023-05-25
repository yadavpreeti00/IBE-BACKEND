using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class RoomRateData
    {
        [JsonProperty("basic_nightly_rate")]
        public double BasicNightlyRate { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }

        public RoomRateData(double basicNightlyRate, string date)
        {
            this.BasicNightlyRate = basicNightlyRate;
            this.Date = date;
        }
    }
}
