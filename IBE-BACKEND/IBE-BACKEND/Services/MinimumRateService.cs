using Amazon.DynamoDBv2.Model;
using GraphQL.Client.Abstractions;
using IBE_BACKEND.Models.GraphQLResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Text.Json.Nodes;

namespace IBE_BACKEND.Services
{
    public class MinimumRateService
    {
        private readonly GraphQLClientService _graphQLClientService;
        public MinimumRateService(GraphQLClientService graphQLClientService)
        {
            _graphQLClientService = graphQLClientService;
        }
        public async Task<Dictionary<string, long>> GetMinimumRateDateMapping()
        {
            try
            {
                JsonObject response = await _graphQLClientService.SendQueryAsync<JsonObject>(GraphQLQueries.Queries.minimumNightlyRateQuery);
                JObject parsedResponse = JObject.Parse(response.ToString());
                JArray listRoomTypes = parsedResponse["data"]["listRoomTypes"] as JArray;

         
                var minimumNightlyRate = listRoomTypes
                            //flatten the response 
                            .SelectMany(roomTypeNode => roomTypeNode.Value<JObject>()["room_rates"].Value<JArray>())
                            .Select(roomRateNode => roomRateNode.Value<JObject>()["room_rate"].Value<JObject>())
                            .Select(rateNode => new
                            {
                                BasicNightlyRate = rateNode["basic_nightly_rate"].Value<long>(),
                                Date = rateNode["date"].Value<string>().Split('T')[0]
                            })
                            //group by date
                            .GroupBy(x => x.Date)
                            //key is the key of group , and value is the min of basic rate of that grp
                            .ToDictionary(g => g.Key, g => g.Min(x => x.BasicNightlyRate));

                Dictionary<string, long> minimumNightlyRateDictionary = new Dictionary<string, long>(minimumNightlyRate);


                return minimumNightlyRateDictionary;
            }
            catch (ResourceNotFoundException ex)
            {
                throw new ResourceNotFoundException(ex);
            }
        }

    }

}
