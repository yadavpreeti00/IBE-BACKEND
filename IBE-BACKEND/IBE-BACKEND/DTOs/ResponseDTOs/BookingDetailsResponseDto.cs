namespace IBE_BACKEND.DTOs.ResponseDTOs
{
    public class BookingDetailsResponseDto
    {
        public string BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? PromoTitle { get; set; }
        public string CardNumber { get; set; }
        public string PropertyId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string Guests { get; set; }
        public string? PromoDescription { get; set; }
        public string NightlyRate { get; set; }
        public string Subtotal { get; set; }
        public string Taxes { get; set; }
        public string Vat { get; set; }
        public string TotalForStay { get; set; }
        public string RoomType { get; set; }
        public List<string>? RoomsList { get; set; }
        public string MailingAddress1 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string RoomCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
