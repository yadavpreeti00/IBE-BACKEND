using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Models;

namespace IBE_BACKEND.Interface
{
    public interface IBookingStatusService
    {
        public BookingStatus SetBookingStatus(string bookingId, bool status);
        public BookingStatusResponseDto GetBookingStatus(string bookingId);
        public BookingDetail SetBookingDetails(BookingDetail bookingDetail);
        public BookingDetailsResponseDto GetBookingDetails(string bookingId);
        public string CancelBooking(string bookingId);
        public List<BookingDetail> GetBookingDetailsForUser(string userId);





    }
}
