using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Exceptions;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models;

namespace IBE_BACKEND.Services.DatabaseServices
{
    public class BookingStatusService : IBookingStatusService
    {
        private readonly team03Context _context ;
        private readonly ILogger<BookingStatusService> _logger ;

        public BookingStatusService (team03Context context,ILogger<BookingStatusService>logger)
        {
            _context = context ;
            _logger = logger ;
        }

    

        public BookingStatusResponseDto GetBookingStatus(string bookingId)
        {
            var bookingStatus = _context.BookingStatuses
                .FirstOrDefault(b => b.BookingId == bookingId);
            if (bookingStatus == null)
            {
                throw new CustomException("Could not find booking status", 400);
            }
            BookingStatusResponseDto response = new BookingStatusResponseDto
            {
                BookingId = bookingStatus.BookingId,
                BookingStatus = bookingStatus.BookingStatus1
            };
            return response;
        }

        public BookingDetail SetBookingDetails(BookingDetail bookingDetail)
        {
            try
            {
                _context.BookingDetails.Add(bookingDetail);
                return bookingDetail;
            }
            catch (Exception)
            {

                throw new Exception("failed to store booking details.");
            }
            
        }

        public BookingStatus SetBookingStatus(string bookingId, bool status)
        {
            BookingStatus bookingStatus = new BookingStatus
            {
                BookingId = bookingId,
                BookingStatus1 = status
            };

            _context.BookingStatuses.Add(bookingStatus);
            _context.SaveChanges();
            return bookingStatus;
        }

        public BookingDetailsResponseDto GetBookingDetails(string bookingId)
        {
            var bookingDetails = _context.BookingDetails
                .FirstOrDefault(b => b.BookingId == bookingId);
            if (bookingDetails == null)
            {
                throw new CustomException("Could not find booking details", 400);
            }
            BookingDetailsResponseDto response = new BookingDetailsResponseDto
            {
                BookingId = bookingDetails.BookingId,
                FirstName = bookingDetails.FirstName,
                LastName = bookingDetails.LastName,
                Phone=bookingDetails.Phone,
                Email=bookingDetails.Email,
                PromoTitle=bookingDetails.PromoTitle,
                PromoDescription=bookingDetails.PromotionDescription,
                CardNumber=bookingDetails.CardNumber,
                PropertyId=bookingDetails.PropertyId,
                CheckInDate=bookingDetails.CheckInDate,
                CheckOutDate=bookingDetails.CheckOutDate,
                Guests=bookingDetails.Guests,
                NightlyRate=bookingDetails.NightlyRate,
                Subtotal=bookingDetails.Subtotal,
                Taxes=bookingDetails.Taxes,
                Vat=bookingDetails.Vat,
                TotalForStay=bookingDetails.TotalForStay,   
                RoomType=bookingDetails.RoomType,
                RoomsList = bookingDetails.RoomsList.Split(',').ToList(),
                MailingAddress1 = bookingDetails.MailingAddress1,
                Country=bookingDetails.Country,
                State=bookingDetails.State,
                Zip=bookingDetails.Zip,
                RoomCount=bookingDetails.RoomCount,
                IsDeleted=bookingDetails.IsDeleted

            };
            return response;
        }

        public string CancelBooking(string bookingId)
        {
            try
            {
                var bookingDetails = _context.BookingDetails.FirstOrDefault(b => b.BookingId == bookingId);
                if (bookingDetails == null)
                {
                    _logger.LogError("Could not find booking the booking with given booking id :" + bookingId);
                    throw new CustomException("Could not find booking the booking with given booking id.", 400);
                }

                bookingDetails.IsDeleted = true;
                _context.SaveChanges();

                string response = "Booking with booking id " + bookingId + "cancelled successfully.";
                return response;
            }
            catch (CustomException ex)
            {
                _logger.LogError($"{ex.Message}");
                throw new CustomException("Cannot delete booking", 500);
            }
            
        }

        public List<BookingDetail> GetBookingDetailsForUser(string userId)
        {
            var bookingDetails = _context.BookingDetails.Where(b => b.UserId == userId).ToList();
            if(bookingDetails.Count<=0)
            {
                _logger.LogError($"Cannot find booking details for user with userId: {userId}");
                throw new CustomException($"Cannot find booking details for user with userId: {userId}", 400);
            }
            return bookingDetails;
        }
    }
}
