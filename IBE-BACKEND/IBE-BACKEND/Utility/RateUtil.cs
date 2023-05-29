using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Exceptions;
using IBE_BACKEND.Models.GraphQLResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IBE_BACKEND.Utility
{
    public static class RateUtil
    {
        public static Dictionary<string, double> CalculateAverageRatePerStay(SearchRoomRatesQueryResponse response, long stayRange, int requestPropertyId)
        {


            var roomTypeToRateMap = new Dictionary<string, double>();

            foreach (var roomRate in response.ListRoomTypes)
            {
                double roomTypeRate = roomRate.BasicNightlyRate;
                Console.WriteLine("roomtyperate");
                Console.WriteLine(roomTypeRate);

                roomRate.RoomTypes.ForEach(roomType => { Console.WriteLine(roomType.RoomType.RoomTypeName); });



                var filteredRoomTypes = roomRate.RoomTypes
                    .Where(roomType => roomType.RoomType.PropertyId == requestPropertyId)
                    .Select(roomType => roomType.RoomType.RoomTypeName).ToList();

                roomRate.RoomTypes.ForEach(roomType => { Console.WriteLine(roomType.RoomType.PropertyId); });

                foreach (var roomTypeName in filteredRoomTypes)
                {
                    if (roomTypeToRateMap.ContainsKey(roomTypeName))
                    {
                        roomTypeToRateMap[roomTypeName] += roomTypeRate;
                    }
                    else
                    {
                        roomTypeToRateMap[roomTypeName] = roomTypeRate;
                    }
                }
            }

            foreach (var roomTypeToRate in roomTypeToRateMap.ToList())
            {
                double value = roomTypeToRate.Value;
                value = value / stayRange;
                value = Math.Round(value * 100.0) / 100.0; // rounding off to 2 decimal places

                roomTypeToRateMap[roomTypeToRate.Key] = value;
            }


            return roomTypeToRateMap;
        }


        public static Dictionary<string, int> GetPriceBreakdown(RoomRatesResponseData roomRatesResponse, PriceBreakdownRequestDto priceBreakdownRequest, Dictionary<string, int> priceBreakDownResult)
        {
            try
            {
                List<RoomType> listRoomTypes = roomRatesResponse.ListRoomTypes;
                foreach (RoomType roomType in listRoomTypes)
                {
                    if (!priceBreakdownRequest.RoomType.Equals(roomType.RoomTypeName, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    var roomRates = roomType.RoomRates;
                    foreach (var roomRate in roomRates)
                    {
                        DateTime startDate = DateUtil.ConvertToDate(priceBreakdownRequest.StartDate);
                        DateTime endDate = DateUtil.ConvertToDate(priceBreakdownRequest.EndDate);
                        DateTime currentDate = DateUtil.ConvertToDate(roomRate.RoomRateData.Date);

                        if ((currentDate > startDate && currentDate < endDate) || currentDate == startDate || currentDate == endDate)
                        {
                            int price = (int)roomRate.RoomRateData.BasicNightlyRate;

                            priceBreakDownResult[currentDate.ToString("yyyy-MM-dd")] = price;
                        }
                    }
                }
                return priceBreakDownResult;
            }
            catch (CustomException ex)
            {
                throw new CustomException($"Failed to process price break down response {ex.Message}", 500);
            }
            
        }
    }

}
