using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.DTOs.ResponseDTOs;

namespace IBE_BACKEND.Interface
{
    public interface ISearchResultsService
    {
        public Task<HashSet<AvailableRoomResponseDto>> GetSearchResults(AvailableRoomRequestDto availableRoomRequestDto);
    }
}
