using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Interface;
using IBE_BACKEND.Models;
using IBE_BACKEND.Models.GraphQLResponseModels;
using IBE_BACKEND.Utility;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IBE_BACKEND.Services
{
    public class PromotionsService : IPromotionsService
    {
        private readonly GraphQLClientService _graphQLClientService;
        private readonly team03Context _team03Context;
        public PromotionsService(GraphQLClientService graphQLClientService, team03Context team03Context)
        {
            _graphQLClientService = graphQLClientService;
            _team03Context = team03Context;
        }

        public async Task<HashSet<PromotionsResponseDto>> GetDefaultPromotions(PromotionRequestDto promotionRequestBody)
        {
            GraphQlResponseModel<DefaultPromotionsResponseModel> response = await _graphQLClientService.SendQueryAsync<GraphQlResponseModel<DefaultPromotionsResponseModel>>(GraphQLQueries.Queries.defaultPromotions);
            List<PromotionResponseModel> promos = response.Data.ListPromotions;
            long stayRange = DateUtil.GetDaysInBetween(promotionRequestBody.StartDate, promotionRequestBody.EndDate);
            HashSet<PromotionsResponseDto> promotionsResponseDtoSet = promos
              .Where(promo => !promo.IsDeactivated && PromotionUtil.CheckValidPromotion(promo, stayRange, promotionRequestBody))
              .Select(promo => new PromotionsResponseDto(null, promo.IsDeactivated, promo.MinimumDaysOfStay, promo.PriceFactor, promo.PromotionDescription, promo.PromotionTitle, promo.PromotionId))
              .ToHashSet();
            return promotionsResponseDtoSet;
        }

        public async Task<PromotionsResponseDto> GetCustomPromotion(PromotionRequestDto promotionRequestBody)
        {
            var promoCode = promotionRequestBody.PromoCode;
            CustomPromotion? customPromotion = await _team03Context.CustomPromotions
                .FirstOrDefaultAsync(p => p.PromoCode == promoCode);

            if (customPromotion == null)
            {
                throw new InvalidDataException("Invalid promo code");
            }

            PromotionsResponseDto promotionsResponseDto = new PromotionsResponseDto(customPromotion.PromoCode, customPromotion.IsDeactivated, customPromotion.MinimumDaysOfStay, customPromotion.PriceFactor, customPromotion.PromotionDescription, customPromotion.PromotionTitle, customPromotion.PromotionId);
            long stayRange = DateUtil.GetDaysInBetween(promotionRequestBody.StartDate, promotionRequestBody.EndDate);
            PromotionResponseModel promotionResponseModel = new PromotionResponseModel(customPromotion.IsDeactivated, customPromotion.MinimumDaysOfStay, customPromotion.PriceFactor, customPromotion.PromotionDescription, customPromotion.PromotionId, customPromotion.PromotionTitle);
            if (!customPromotion.IsDeactivated &&
                    PromotionUtil.CheckValidPromotion(promotionResponseModel, stayRange, promotionRequestBody) &&
                    promotionRequestBody.RoomType.Contains(customPromotion.ApplicableRoomType))
            {
                return promotionsResponseDto;
            }
            else
            {
                throw new InvalidDataException("Promo conditions not valid");

            }

        }



    }
}
