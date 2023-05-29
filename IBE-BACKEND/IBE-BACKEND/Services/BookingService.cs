using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models;
using IBE_BACKEND.Services.DatabaseServices;
using IBE_BACKEND.Utility;

namespace IBE_BACKEND.Services
{
    public class BookingService : IBookingService
    {
        private readonly team03Context _team03Context;
        private readonly IBookingStatusService _bookingStatusService ;

        

        public BookingService(team03Context team03Context, IBookingStatusService bookingStatusService)
        {
            _team03Context = team03Context;
            _bookingStatusService = bookingStatusService;
        }
        
        


        public string CreateBooking(QueueBookingRequestDto bookingRequestDto, List<int> roomIdsAvailable)
        {
            if (_team03Context == null || _bookingStatusService == null)
            {
                throw new InvalidOperationException("Dependencies not initialized properly.");
            }

            BookingDetail bookingDetail = BookingUtil.MapToBookingDetails(bookingRequestDto);
            _bookingStatusService.SetBookingStatus(bookingRequestDto.bookingId, true);
            _bookingStatusService.SetBookingDetails(bookingDetail);

            //_team03Context.BookingDetails.Add(bookingDetail);
            string sucessMsg = "Booking created with booking id :" + bookingRequestDto.bookingId;
            return sucessMsg;
            
        }
    }
}
