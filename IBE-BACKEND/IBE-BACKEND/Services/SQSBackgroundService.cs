using Amazon.SQS.Model;
using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.Exceptions;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models;
using IBE_BACKEND.Services.ClientServices;
using IBE_BACKEND.Services.DatabaseServices;
using IBE_BACKEND.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Text.Json;
using System.Threading;

namespace IBE_BACKEND.Services
{

    public class SqsBackGroundService : BackgroundService
    {
        public readonly SQSClientService _sqsClient = new SQSClientService();
        private readonly IServiceProvider _serviceProvider;
        public SqsBackGroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        //public readonly team03Context _database = new team03Context();

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            await StartListeningAsync(cancellationTokenSource.Token);
        }

        public async Task StartListeningAsync(CancellationToken cancellationToken = default)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // To use the '_context' for DB operations
                var _database = scope.ServiceProvider.GetRequiredService<team03Context>();

                while (true)
                {
                    Console.WriteLine("looking ");
                    var receiveRequest = new ReceiveMessageRequest
                    {
                        QueueUrl = _sqsClient.GetQueueUrl(),
                        MaxNumberOfMessages = 1,
                    };

                    var response = await _sqsClient.GetSqsClient().ReceiveMessageAsync(receiveRequest, cancellationToken);

                    foreach (var message in response.Messages)
                    {
                        //await DeleteMessageAsync(message.ReceiptHandle);
                        Console.WriteLine("body" + message.Body);
                        try
                        {
                            QueueBookingRequestDto bookingRequestDto = JsonSerializer.Deserialize<QueueBookingRequestDto>(message.Body);
                            Console.WriteLine(bookingRequestDto.bookingId);
                            Console.WriteLine(bookingRequestDto.first_name);
                            //List<int> roomIdsAvailableForBooking = _roomAvailabilityService.RoomCountAvailableForBooking(bookingRequest);
                            //bool isBookingFailed = _roomAvailabilityService.CheckForFailedBooking(bookingRequest, roomIdsAvailableForBooking);
                            List<int> roomIdsAvailableForBooking = new List<int>();
                            bool isBookingFailed = false;
                            if (isBookingFailed)
                            {
                                await DeleteMessageAsync(message.ReceiptHandle);
                            }
                            else
                            {
                                bool canBeBookedNow = true;
                                if (canBeBookedNow)
                                {
                                    //check for overlapping here
                                    //_bookingService.CreateBooking(bookingRequest, roomIdsAvailableForBooking);
                                    //BookingDetail bookingDetail = BookingUtil.MapToBookingDetails(bookingRequest);
                                    //_bookingStatusService.SetBookingStatus(bookingRequest.bookingId, true);
                                    //_bookingStatusService.SetBookingDetails(bookingDetail);
                                    DateTime startDate = DateTime.ParseExact(bookingRequestDto.check_in_date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
                                    DateTime endDate = DateTime.ParseExact(bookingRequestDto.check_out_date, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
                                    int numOfDays = (int)(endDate - startDate).TotalDays;
                                    double totalPrice = double.Parse(bookingRequestDto.total_for_stay);
                                    double nightlyRate = totalPrice / numOfDays;

                                    BookingDetail bookingDetail = new BookingDetail
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
                                        RoomsList = string.Join(",", BookingUtil.GetRoomId(bookingRequestDto.room_count)),

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
                                    _database.BookingDetails.Add(bookingDetail);

                                    BookingStatus bookingStatus = new BookingStatus
                                    {
                                        BookingId = bookingRequestDto.bookingId,
                                        BookingStatus1 = true
                                    };

                                    _database.BookingStatuses.Add(bookingStatus);
                                    _database.SaveChanges();




                                    //_team03Context.BookingDetails.Add(bookingDetail);
                                    string sucessMsg = "Booking created with booking id :" + bookingRequestDto.bookingId;
                                    Console.WriteLine(sucessMsg);
                                    await DeleteMessageAsync(message.ReceiptHandle);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                            throw new CustomException(ex.Message, 500);
                        }
                    }
                }
            }
        }

        private async Task DeleteMessageAsync(string receiptHandle, CancellationToken cancellationToken = default)
        {
            try
            {
                var deleteRequest = new DeleteMessageRequest
                {
                    QueueUrl = _sqsClient.GetQueueUrl(),
                    ReceiptHandle = receiptHandle
                };

                await _sqsClient.GetSqsClient().DeleteMessageAsync(deleteRequest, cancellationToken);
            }
            catch (Exception)
            {

                throw new Exception("failed to delete message from the queue.");
            }

        }
    }
}
