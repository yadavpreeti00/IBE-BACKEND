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
        private readonly ILogger<ConfigurationDataService> _logger;

        public ConfigurationDataService(IAmazonDynamoDB dynamoDbClient,IConfiguration configuration, ILogger<ConfigurationDataService> logger)
        {
            _dynamoDbClient = dynamoDbClient;
            _configuration = configuration;
            _logger = logger;
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
                var item = response.Items[1];

                var configurationItem = new ConfigurationResponse
                {
                    TenantId = item["tenantId"].S,
                    Page = item["page"].S,
                    Configuration = item["configuration"].S
                };
                return configurationItem;
            }
            else
            {
                _logger.LogError("Failed ot get landing page data from dynamo db table");
                throw new CustomException("Could not get landing Page data", 500);
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
                var item = response.Items[2];

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
                _logger.LogError("Failed ot get room results page data from dynamo db table");
                throw new CustomException("Could not get room results Page data",500);
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
                _logger.LogError("Failed ot get checkout page data from dynamo db table");
                throw new CustomException("Could not get checkout Page data",500);
            }
        }
    }
}
