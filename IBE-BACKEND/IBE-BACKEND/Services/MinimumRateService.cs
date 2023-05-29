using Amazon.DynamoDBv2.Model;
using GraphQL.Client.Abstractions;
using IBE_BACKEND.Exceptions;
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
        private readonly ILogger<MinimumRateService> _logger;
        public MinimumRateService(GraphQLClientService graphQLClientService,ILogger<MinimumRateService>logger)
        {
            _graphQLClientService = graphQLClientService;
            _logger = logger;
        }
        public async Task<Dictionary<string, double>> GetMinimumRateDateMapping()
        {
            try
            {
                GraphQlResponseModel<MinimumNightlyRateResponse> response = await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<MinimumNightlyRateResponse>>(GraphQLQueries.Queries.minimumNightlyRateQuery);

                List<MinimumNightlyRateRoomType> listRoomTypes = response.Data.ListRoomTypes;

                var minimumNightlyRate = listRoomTypes
                    //flatten the response
                    .SelectMany(roomType => roomType.RoomRates)
                    .Select(roomRate => roomRate.RoomRate)
                    .Select(rate => new
                    {
                        BasicNightlyRate = rate.BasicNightlyRate,
                        Date = rate.Date,
                    })
                    //group by date
                    .GroupBy(x => x.Date)
                    //key is the key of group , and value is the min of basic rate of that grp
                    .ToDictionary(g => g.Key, g => g.Min(x => x.BasicNightlyRate));

                Dictionary<string, double> minimumNightlyRateDictionary = new Dictionary<string, double>(minimumNightlyRate);


                return minimumNightlyRateDictionary;
            }
            catch (CustomException ex)
            {
                _logger.LogError($"{ex.Message}, minimum rate service failed");
                throw new CustomException("Failed to get minimum rates.",500);
            }
        }

    }

}
