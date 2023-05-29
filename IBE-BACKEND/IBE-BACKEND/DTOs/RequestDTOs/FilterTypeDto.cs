using Newtonsoft.Json;

namespace IBE_BACKEND.DTOs.RequestDTOs
{
    public class FilterTypeDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("attribute")]
        public string Attribute { get; set; }
        [JsonProperty("values")]
        public string[] Values { get; set; }

    }
}
