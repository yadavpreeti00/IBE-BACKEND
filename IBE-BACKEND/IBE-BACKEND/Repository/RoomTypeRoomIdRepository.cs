using IBE_BACKEND.Interface;
using IBE_BACKEND.Models;

namespace IBE_BACKEND.Repository
{
    public class RoomTypeRoomIdRepository : IRoomTypeRoomIdRepository
    {
        private readonly team03Context _context;

        public RoomTypeRoomIdRepository(team03Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Find which rooms of a room type are available between given check in and checkout days
        /// </summary>
        /// <param name="roomType"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <param name="numDays"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<int> FindAvailableRoomIdsForDateRange(string roomType, DateTime checkInDate, DateTime checkOutDate, long numDays)
        {
            try
            {
                return _context.RoomTypeRoomIds
                            .Where(rtr => rtr.RoomType == roomType &&
                                          rtr.BookingId == "0" &&
                                          DateTime.Parse(rtr.Date) >= checkInDate &&
                                          DateTime.Parse(rtr.Date) < checkOutDate)
                            .GroupBy(rtr => rtr.RoomId)
                            .Where(group => group.Count() == numDays)
                            .Select(group => group.Key)
                            .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update the booking id in the database if the booking is sucessful
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <param name="bookingId"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateBookingIdByRoomIdAndDateRange(int roomId, DateTime checkInDate, DateTime checkOutDate, string bookingId)
        {
            try
            {
                List<RoomTypeRoomId> roomIdsListToUpdate = _context.RoomTypeRoomIds
                .Where(rtr => rtr.RoomId == roomId &&
                               DateTime.Parse(rtr.Date) >= checkInDate &&
                               DateTime.Parse(rtr.Date) < checkOutDate)
                .ToList();

                foreach (RoomTypeRoomId entry in roomIdsListToUpdate)
                {
                    entry.BookingId = bookingId;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
