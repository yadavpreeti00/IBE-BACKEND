using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Models;
using System.Globalization;

namespace IBE_BACKEND.Utility
{
    public static class BookingUtil
    {
        public static string GenerateRandomBookingId()
        {
            string uuid = Guid.NewGuid().ToString();
            return uuid.Substring(0, 10);
        }

        public static BookingDetail MapToBookingDetails(QueueBookingRequestDto bookingRequestDto)
        {
            try
            {
                DateTime startDate = DateTime.ParseExact(bookingRequestDto.check_in_date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(bookingRequestDto.check_out_date, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                int numOfDays = (int)(endDate - startDate).TotalDays;
                double totalPrice = double.Parse(bookingRequestDto.total_for_stay);
                double nightlyRate = totalPrice / numOfDays;

                return new BookingDetail
                {
                    BookingId = bookingRequestDto.bookingId,
                    CardNumber = bookingRequestDto.card_number,
                    CheckInDate = bookingRequestDto.check_in_date,
                    CheckOutDate = bookingRequestDto.check_out_date,
                    Country = bookingRequestDto.country,
                    CreatedAt = DateTime.Now,
                    Email = bookingRequestDto.email,
                    FirstName = bookingRequestDto.first_name,
                    Guests = bookingRequestDto.guests,
                    IsDeleted = false,
                    LastName = bookingRequestDto.last_name,
                    MailingAddress1 = bookingRequestDto.mailing_address1,
                    NightlyRate = nightlyRate.ToString("0.00"),
                    Phone = bookingRequestDto.phone,
                    PromotionDescription = bookingRequestDto.promo_description,
                    PromoTitle = bookingRequestDto.promo_title,
                    PropertyId = bookingRequestDto.property_id,
                    RoomCount = bookingRequestDto.room_count,
                    RoomType = bookingRequestDto.room_type,
                    RoomsList = null,
                    State = bookingRequestDto.state,
                    Subtotal = bookingRequestDto.subtotal,
                    Taxes = bookingRequestDto.taxes,
                    TotalForStay = bookingRequestDto.total_for_stay,
                    UpdatedAt = DateTime.Now,
                    Vat = bookingRequestDto.vat,
                    Zip = bookingRequestDto.zip,
                    UserId = null,
                    CustomPromotionPromoCode = null
                };

            }
            catch (Exception)
            {

                throw new Exception("Failed to map data to booking details");
            }
        }

        public static List<string> GetRoomId(string roomCount)
        {
            if (!int.TryParse(roomCount, out int count))
            {
                throw new ArgumentException("Invalid room count. The room count must be a valid integer.");
            }

            List<string> roomIds = new List<string>();

            for (int i = 1; i <= count; i++)
            {
                string roomId = i.ToString();
                roomIds.Add(roomId);
            }

            return roomIds;
        }



    }
}
