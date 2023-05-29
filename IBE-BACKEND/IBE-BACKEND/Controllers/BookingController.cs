using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models;
using IBE_BACKEND.Services;
using IBE_BACKEND.Services.ClientServices;
using IBE_BACKEND.Services.DatabaseServices;
using IBE_BACKEND.Utility;
using Microsoft.AspNetCore.Mvc;

namespace IBE_BACKEND.Controllers
{
    [ApiController]
    public class BookingController : Controller
    {
        private readonly SQSClientService _sQSClient;
        private readonly IBookingStatusService _bookingStatusService;
        public BookingController (SQSClientService sQSClient,IBookingStatusService bookingStatusService)
        {
            _sQSClient = sQSClient;
            _bookingStatusService = bookingStatusService;
        }

        [HttpPost]
        [Route("/PushBooking")]
        public IActionResult PushBooking(QueueBookingRequestDto bookingRequestDto)
        {
            bookingRequestDto.bookingId=BookingUtil.GenerateRandomBookingId();
            QueueBookingResponseDto response =_sQSClient.SendMessageToSQS(bookingRequestDto);
            return Ok(response);
        }

        [HttpGet("BookingStatus/{bookingId}")]
        public IActionResult GetBookingStatus(string bookingId)
        {
            var response = _bookingStatusService.GetBookingStatus(bookingId);
            return Ok(response);
        }

        [HttpGet("BookingDetails/{bookingId}")]
        public IActionResult GetBookingDetails(string bookingId)
        {
            var response = _bookingStatusService.GetBookingDetails(bookingId);
            return Ok(response);
        }


        [HttpPost("CancelBooking/{bookingId}")]
        public IActionResult CancelBooking(string bookingId)
        {
            var response = _bookingStatusService.CancelBooking(bookingId);
            return Ok(response);
        }

        [HttpGet("MyBookings/{userId}")]
        public IActionResult GetBookingDetailsForUser(string userId)
        {
            List<BookingDetail> bookingDetailsList = _bookingStatusService.GetBookingDetailsForUser(userId);
            return Ok(bookingDetailsList);
        }
    }
}
