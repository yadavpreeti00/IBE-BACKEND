using Amazon.Runtime.CredentialManagement;
using Amazon.SSO;
using System;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using IBE_BACKEND.DTOs.RequestDTOs;
using Newtonsoft.Json;
using IBE_BACKEND.DTOs.ResponseDTOs;

namespace IBE_BACKEND.Services.ClientServices
{
    public class SQSClientService
    {


        private readonly IAmazonSQS sqsClient;
        private readonly string queueUrl = "https://sqs.ap-south-1.amazonaws.com/766971438535/team03queue.fifo";

        public SQSClientService()
        {
            var sharedFile = new SharedCredentialsFile();
            if (sharedFile.TryGetProfile("kdujan23", out var profile))
            {
                var awsCredentials = AWSCredentialsFactory.GetAWSCredentials(profile, sharedFile);
                var awsConfig = new AmazonSQSConfig { RegionEndpoint = RegionEndpoint.GetBySystemName("ap-south-1") };
                sqsClient = new AmazonSQSClient(awsCredentials, awsConfig);
            }
            else
            {
                throw new ArgumentException($"Unable to find AWS profile '{"kdujan23"}' in the shared credentials file.");
            }
        }



        public QueueBookingResponseDto SendMessageToSQS(QueueBookingRequestDto bookingRequestDto)
        {
            try
            {
                string messageBody = JsonConvert.SerializeObject(bookingRequestDto);
                Random random = new Random();
                string randomString = random.Next(100000, 999999).ToString();
                var request = new SendMessageRequest
                {
                    QueueUrl = queueUrl,
                    MessageBody = messageBody,
                    MessageGroupId = randomString
                };
                var response = sqsClient.SendMessageAsync(request).GetAwaiter().GetResult();
                if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Failed to send message to queue");
                }
                else
                {
                    QueueBookingResponseDto queueBookingResponse=new QueueBookingResponseDto();
                    queueBookingResponse.BookingId = bookingRequestDto.bookingId;
                    return queueBookingResponse;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public string GetQueueUrl()
        {
            return queueUrl;
        }
        public IAmazonSQS GetSqsClient()
        {
            return sqsClient;
        }
    }
}

