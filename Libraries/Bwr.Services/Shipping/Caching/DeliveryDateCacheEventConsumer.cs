using Bwr.Core.Domain.Shipping;
using Bwr.Services.Caching;

namespace Bwr.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a delivery date cache event consumer
    /// </summary>
    public partial class DeliveryDateCacheEventConsumer : CacheEventConsumer<DeliveryDate>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(DeliveryDate entity)
        {
            Remove(NopShippingDefaults.DeliveryDatesAllCacheKey);
        }
    }
}