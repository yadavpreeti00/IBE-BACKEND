using IBE_BACKEND.Models.DynamoDbResponseModels;

namespace IBE_BACKEND.Interface
{
    public interface IConfigurationDataService
    {
        public Task<ConfigurationResponse> GetLandingPageConfigurationData();
        public Task<ConfigurationResponse> GetRoomResultsPageConfigurationData();
        public Task<ConfigurationResponse> GetCheckoutPageConfigurationData();

    }
}
