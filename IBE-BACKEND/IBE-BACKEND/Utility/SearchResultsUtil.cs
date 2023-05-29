using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Models.GraphQLResponseModels;

namespace IBE_BACKEND.Utility
{
    public static class SearchResultsUtil
    {
        public static void FormAvailableRoomResultsResponseDto(Dictionary<string, double> roomRatesResult, SearchResultsQueryResponse response, long stayRange, int roomCount, HashSet<AvailableRoomResponseDto> availableRoomResult)
        {
            Dictionary<string, Dictionary<long, long>> roomTypeToRoomIds = new Dictionary<string, Dictionary<long, long>>();
            List<SearchListRoomAvailabilitiesResponse> listRoomAvailabilities = response.ListRoomAvailabilities;

            foreach (SearchListRoomAvailabilitiesResponse availability in listRoomAvailabilities)
            {
                
                string roomTypeName = availability.Room.RoomType.RoomTypeName;
                long roomId = availability.RoomId;

                if (!roomTypeToRoomIds.ContainsKey(roomTypeName))
                {
                    roomTypeToRoomIds[roomTypeName] = new Dictionary<long, long>();
                }

                Dictionary<long, long> roomCountMap = roomTypeToRoomIds[roomTypeName];

                if (roomCountMap.ContainsKey(roomId))
                {
                    roomCountMap[roomId]++;
                }
                else
                {
                    roomCountMap[roomId] = 1;
                }
            }

            foreach (string roomTypeName in roomTypeToRoomIds.Keys.ToList())
            {
                Dictionary<long, long> roomIds = roomTypeToRoomIds[roomTypeName];
                long roomsAvailableBetweenDateRange = roomIds.Values.Count(value => value >= stayRange);

                if (roomsAvailableBetweenDateRange < roomCount)
                {
                    roomTypeToRoomIds.Remove(roomTypeName);
                }
                else
                {
                    SearchResultRoomType roomType = response.ListRoomAvailabilities
                        .Select(availability => availability.Room.RoomType)
                        .FirstOrDefault(rt => rt.RoomTypeName == roomTypeName);

                    double roomRate = roomRatesResult.GetValueOrDefault(roomTypeName, 0);
                    string roomTypeString = roomType != null ? roomType.RoomTypeName : null;
                //    double rating = roomRatingRepository.GetAverageRatingByRoomType(roomTypeString) ?? 0;
                //    string ratingAsString = rating.ToString("N1");
                //    long reviewers = roomRatingRepository.GetCountOfRatedRooms(roomTypeString);


                    AvailableRoomResponseDto roomDto = new AvailableRoomResponseDto(roomType.RoomTypeName, roomType.RoomTypeId, roomType.SingleBed, roomType.DoubleBed, roomType.SingleBed + roomType.DoubleBed, roomType.MaxCapacity, (int)roomType.AreaInSquareFeet, false,null,roomRate,"NA",0L);

                    availableRoomResult.Add(roomDto);
                }
            }
        }
    }
}
