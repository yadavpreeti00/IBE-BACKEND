using Newtonsoft.Json;

namespace IBE_BACKEND.DTOs.RequestDTOs
{
    public class SortTypeDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("attribute")]
        public string Attribute { get; set; }
        [JsonProperty("order")]
        public string Order { get; set; }
    }
}
