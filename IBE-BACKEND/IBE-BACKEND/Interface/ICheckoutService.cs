using IBE_BACKEND.DTOs.RequestDTOs;
using System.Collections.Concurrent;

namespace IBE_BACKEND.Interface
{
    public interface ICheckoutService
    {
        public Task<Dictionary<string, int>> GetPriceBreakDown(PriceBreakdownRequestDto priceBreakdownRequest);
    }
}
