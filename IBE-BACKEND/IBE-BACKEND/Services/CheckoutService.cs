using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Exceptions;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models.GraphQLResponseModels;
using IBE_BACKEND.Utility;
using System.Collections.Concurrent;

namespace IBE_BACKEND.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly GraphQLClientService _graphQLClientService;
        private readonly ILogger<CheckoutService> _logger;
        public CheckoutService(GraphQLClientService graphQLClientService,ILogger<CheckoutService> logger)
        {
               _graphQLClientService = graphQLClientService;
               _logger = logger;
        }
        public async Task<Dictionary<string, int>> GetPriceBreakDown(PriceBreakdownRequestDto priceBreakdownRequest)
        {
            try
            {
                var response = await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<RoomRatesResponseData>>(GraphQLQueries.Queries.roomRatesBreakDown);

                if (response == null)
                {
                    _logger.LogError("Failed to retrieve price break down from graphql.");
                    throw new CustomException("Failed to fetch price breakdown data from graphql.",500);
                }
                Dictionary<string, int> priceBreakDownResult = new Dictionary<string, int>();
                RateUtil.GetPriceBreakdown(response.Data, priceBreakdownRequest, priceBreakDownResult);
                return priceBreakDownResult;
            }
            catch (CustomException ex)
            {
                _logger.LogError($"{ex.Message}, price break down api failed");
                throw new CustomException("Price Breakdown Api failed", 500);
            }
            
        }
    }
}
