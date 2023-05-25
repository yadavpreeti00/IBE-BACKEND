using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models.GraphQLResponseModels;
using IBE_BACKEND.Models.GraphQLResponseModels.SearchResultsRatesQueryResponse;
using IBE_BACKEND.Utility;
using System.Collections.Generic;

namespace IBE_BACKEND.Services
{
    public class SearchResultsService : ISearchResultsService
    {
        private readonly GraphQLClientService _graphQLClientService;
        public SearchResultsService(GraphQLClientService graphQLClientService)
        {
            _graphQLClientService = graphQLClientService;
        }

        public SearchResultsService() { }
        public async Task<HashSet<AvailableRoomResponseDto>> GetSearchResults(AvailableRoomRequestDto availableRoomRequestBody)
        {
			try
			{
                long stayRange = DateUtil.GetDaysInBetween(availableRoomRequestBody.StartDate, availableRoomRequestBody.EndDate);
                HashSet<AvailableRoomResponseDto> availableRoomsResults = new HashSet<AvailableRoomResponseDto>();
                if(availableRoomRequestBody.SortType !=null)
                {
                   

                }
                string query = string.Format(GraphQLQueries.Queries.rateBetweenDateRangeQuery, availableRoomRequestBody.StartDate, availableRoomRequestBody.EndDate, availableRoomRequestBody.PropertyId);

                GraphQlResponseModel<SearchRatesModel> response = await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<SearchRatesModel>>(query);

                if(response == null)
                {
                    throw new Exception("failed to retrieve room rates from API.");
                }





            }
            catch (Exception)
			{

				throw;
			}
        }
    }
}
