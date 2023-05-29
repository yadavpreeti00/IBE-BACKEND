using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Repository;
using System.Globalization;

namespace IBE_BACKEND.Services
{
    public class RoomAvailablityService : IRoomAvailabilityService
    {
        private readonly IRoomTypeRoomIdRepository _roomTypeRoomIdRepository;
        private readonly IBookingStatusService _bookingStatusService;

        public RoomAvailablityService()
        {
        }

        public RoomAvailablityService(IRoomTypeRoomIdRepository roomTypeRoomIdRepository, IBookingStatusService bookingStatusService)
        {
            _roomTypeRoomIdRepository = roomTypeRoomIdRepository;
            _bookingStatusService = bookingStatusService;

        }

        public bool CheckForFailedBooking(QueueBookingRequestDto bookingRequestDto, List<int> roomIdsAvailableForBooking)
        {
            try
            {
                int roomCount = int.Parse(bookingRequestDto.room_count);
                if (roomIdsAvailableForBooking.Count < roomCount)
                {
                    _bookingStatusService.SetBookingStatus(bookingRequestDto.bookingId, false);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<int> RoomCountAvailableForBooking(QueueBookingRequestDto bookingRequestDto)
        {
            try
            {

                string roomType = bookingRequestDto.room_type;
                DateTime startDate = DateTime.ParseExact(bookingRequestDto.check_in_date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                Console.WriteLine(startDate);
                DateTime endDate = DateTime.ParseExact(bookingRequestDto.check_out_date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                long numOfDays = (long)(endDate - startDate).TotalDays;
                Console.WriteLine(numOfDays);
                Console.WriteLine(endDate);
                List<int> roomsAvailable = _roomTypeRoomIdRepository.FindAvailableRoomIdsForDateRange(roomType, startDate, endDate, numOfDays);
                return roomsAvailable;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
