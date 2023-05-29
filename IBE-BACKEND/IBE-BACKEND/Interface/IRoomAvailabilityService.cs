using IBE_BACKEND.DTOs.RequestDTOs;

namespace IBE_BACKEND.Interface
{
    public interface IRoomAvailabilityService
    {
        public bool CheckForFailedBooking(QueueBookingRequestDto bookingRequest, List<int> roomIdsAvailableForBooking);
        public List<int> RoomCountAvailableForBooking(QueueBookingRequestDto bookingRequestDto);

    }
}
