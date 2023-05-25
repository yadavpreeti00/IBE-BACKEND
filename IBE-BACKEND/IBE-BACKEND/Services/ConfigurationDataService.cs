using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using IBE_BACKEND.Exceptions;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models.DynamoDbResponseModels;
using System.Net;

namespace IBE_BACKEND.Services
{
    public class ConfigurationDataService : IConfigurationDataService
    {
        private readonly IAmazonDynamoDB _dynamoDbClient;
        private readonly IConfiguration _configuration;

        public ConfigurationDataService(IAmazonDynamoDB dynamoDbClient,IConfiguration configuration)
        {
            _dynamoDbClient = dynamoDbClient;
            _configuration = configuration;
        }
        public async Task<ConfigurationResponse> GetLandingPageConfigurationData()
        {
            var request = new ScanRequest
            {
                TableName = _configuration["AWS:DynamoDbTable"]

            };

            var response = await _dynamoDbClient.ScanAsync(request);

            if (response.Items.Count > 0)
            {
                var item = response.Items[0];

                var configurationItem = new ConfigurationResponse
                {
                    TenantId = item["tenantId"].S,
                    Page = "LandingPage",
                    Configuration = item["configuration"].S
                };
                return configurationItem;
            }
            else
            {
                throw new ResourceNotFoundException("Could not get landing Page data");
            }
        }

        public async Task<ConfigurationResponse> GetRoomResultsPageConfigurationData()
        {
            var request = new ScanRequest
            {
                TableName = _configuration["AWS:DynamoDbTable"]

            };

            var response = await _dynamoDbClient.ScanAsync(request);

            if (response.Items.Count > 0)
            {
                var item = response.Items[0];

                var configurationItem = new ConfigurationResponse
                {
                    TenantId = item["tenantId"].S,
                    Page = "RoomResultsPage",
                    Configuration = item["configuration"].S
                };
                return configurationItem;
            }
            else
            {
                throw new ResourceNotFoundException("Could not get room results Page data");
            }
        }

        public async Task<ConfigurationResponse> GetCheckoutPageConfigurationData()
        {
            var request = new ScanRequest
            {
                TableName = _configuration["AWS:DynamoDbTable"]

            };

            var response = await _dynamoDbClient.ScanAsync(request);

            if (response.Items.Count > 0)
            {
                var item = response.Items[0];

                var configurationItem = new ConfigurationResponse
                {
                    TenantId = item["tenantId"].S,
                    Page = "CheckoutPage",
                    Configuration = item["configuration"].S
                };
                return configurationItem;
            }
            else
            {
                throw new ResourceNotFoundException("Could not get checkout Page data");
            }
        }
    }
}
