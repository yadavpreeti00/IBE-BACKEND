using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

public class GraphQLClientService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GraphQLClientService( IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _configuration = configuration;
    }

    public async Task<TResponse> SendQueryAsync<TResponse>(string query)
    {
        _httpClient.DefaultRequestHeaders.Add("x-api-key", _configuration["GraphQL:ApiKey"]);
        _httpClient.DefaultRequestHeaders.Add("x-api-id", _configuration["GraphQL:ApiId"]);

        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var request = new HttpRequestMessage(HttpMethod.Post, _configuration["GraphQL:Endpoint"])
        {
            Content = new StringContent(JsonSerializer.Serialize(new { query }), Encoding.UTF8, "application/json")
        };
       
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();


        var responseJson = await response.Content.ReadAsStringAsync();
        Console.WriteLine("----------------------------------" +responseJson);


        TResponse result = JsonConvert.DeserializeObject<TResponse>(responseJson.ToString());
        return result;
    }
}
