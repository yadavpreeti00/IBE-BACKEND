namespace IBE_BACKEND.Models.GraphQLResponseModels
{
    public class DefaultPromotionsResponseModel
    {
        public List<PromotionResponseModel> ListPromotions { get; set; }

        public DefaultPromotionsResponseModel(List<PromotionResponseModel> listPromotions)
        {
            ListPromotions = listPromotions;
        }
    }
}
