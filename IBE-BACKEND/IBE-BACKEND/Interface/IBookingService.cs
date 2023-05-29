using IBE_BACKEND.DTOs.RequestDTOs;
using java.lang;

namespace IBE_BACKEND.Interface
{
    public interface IBookingService
    {
        public string CreateBooking(QueueBookingRequestDto bookingRequestDto, List<int> roomIdsAvailable);
    }
}
