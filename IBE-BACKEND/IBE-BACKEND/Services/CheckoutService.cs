using IBE_BACKEND.Interface;
using System.Collections.Concurrent;

namespace IBE_BACKEND.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly GraphQLClientService _graphQLClientService;
        public CheckoutService(GraphQLClientService graphQLClientService)
        {
               _graphQLClientService = graphQLClientService;
        }
        public async Task<ConcurrentDictionary<DateTime, int>> getPriceBreakDown()
        {
           //  var response = await _graphQLClientService.SendQueryAsync<MinimumNightlyRateResponse>(GraphQLQueries.Queries.roomRatesBreakDown);
            return new ConcurrentDictionary<DateTime, int> { };
        }

    }
}
