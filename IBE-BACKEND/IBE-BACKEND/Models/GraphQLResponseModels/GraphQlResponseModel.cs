using Newtonsoft.Json;

namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class GraphQlResponseModel<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        public GraphQlResponseModel(T data)
        {
            Data = data;
        }
    }
}
