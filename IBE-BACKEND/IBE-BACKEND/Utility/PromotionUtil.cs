using IBE_BACKEND.DTOs.RequestDTOs;
using IBE_BACKEND.DTOs.ResponseDTOs;
using IBE_BACKEND.Models.GraphQLResponseModels;
using System;

namespace IBE_BACKEND.Utility
{
    public class PromotionUtil
    {
        public static bool CheckValidPromotion(PromotionResponseModel promotionDto, long stayRange, PromotionRequestDto promotionRequestBody)
        {
            bool minimumStay = stayRange >= promotionDto.MinimumDaysOfStay;
            bool validPromotion;



            switch (promotionDto.PromotionTitle)
            {
                case "SENIOR_CITIZEN_DISCOUNT":
                case "MILITARY_PERSONNEL_DISCOUNT":
                case "KDU_MEMBERSHIP_DISCOUNT":
                case "DISABLED_DISCOUNT":
                    validPromotion = promotionRequestBody.ApplicableDiscountType != null && promotionDto.PromotionTitle.Equals(promotionRequestBody.ApplicableDiscountType, StringComparison.OrdinalIgnoreCase);
                    break;
                case "LONG_WEEKEND_DISCOUNT":
                case "WEEKEND_DISCOUNT":
                    validPromotion = DateUtil.CheckWeekend(promotionRequestBody.StartDate, promotionRequestBody.EndDate, "allWeekend");
                    break;
                case "WEEKDAYS_DISCOUNT":
                    validPromotion = !DateUtil.CheckWeekend(promotionRequestBody.StartDate, promotionRequestBody.EndDate, "anyWeekend");
                    break;
                default:
                    validPromotion = true;
                    break;
            }


            return minimumStay && validPromotion;
        }


    }
}
