using com.sun.org.apache.bcel.@internal.generic;
using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models.GraphQLResponseModels;
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
               // string query = string.Format(GraphQLQueries.Queries.rateBetweenDateRangeQuery, availableRoomRequestBody.StartDate, availableRoomRequestBody.EndDate, availableRoomRequestBody.PropertyId);
                GraphQlResponseModel<SearchRoomRatesQueryResponse> response = await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<SearchRoomRatesQueryResponse>>(GraphQLQueries.Queries.rateBetweenDateRangeQuery);

                if(response == null)
                {
                    throw new Exception("failed to retrieve room rates from API.");
                }
                Dictionary<string, double> roomRatesResult = RateUtil.CalculateAverageRatePerStay(response.Data, stayRange, availableRoomRequestBody.PropertyId);

               // string searchResultsQuery = string.Format(GraphQLQueries.Queries.searchResultsQuery,  availableRoomRequestBody.StartDate, availableRoomRequestBody.EndDate);
                var searchResultsResponse = await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<SearchResultsQueryResponse>>(GraphQLQueries.Queries.searchResultsQuery);
                if(searchResultsResponse == null)
                {
                    throw new Exception("failed to retrieve available rooms.");
                }

                SearchResultsUtil.FormAvailableRoomResultsResponseDto(roomRatesResult, searchResultsResponse.Data, stayRange, availableRoomRequestBody.RoomCount, availableRoomsResults);
                if (availableRoomRequestBody.FilterTypes != null && availableRoomRequestBody.FilterTypes.Length > 0)
                {
                }

                return availableRoomsResults;
            }
            catch (Exception)
			{

				throw;
			}
        }
    }
}
