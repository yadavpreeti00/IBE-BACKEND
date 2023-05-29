namespace IBE_BACKEND.Interface
{
    public interface IRoomTypeRoomIdRepository
    {
        public List<int> FindAvailableRoomIdsForDateRange(string roomType, DateTime checkInDate, DateTime checkOutDate, long numDays);
        public void UpdateBookingIdByRoomIdAndDateRange(int roomId, DateTime checkInDate, DateTime checkOutDate, string bookingId);
    }
}
