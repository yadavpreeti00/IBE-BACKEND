using System.Collections.Concurrent;

namespace IBE_BACKEND.Interface
{
    public interface ICheckoutService
    {
        public Task<ConcurrentDictionary<DateTime, int>> getPriceBreakDown();
    }
}
