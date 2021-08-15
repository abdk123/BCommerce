using Bwr.Core.Domain.Catalog;
using Bwr.Services.Caching;
using Bwr.Services.Discounts;

namespace Bwr.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a manufacturer cache event consumer
    /// </summary>
    public partial class ManufacturerCacheEventConsumer : CacheEventConsumer<Manufacturer>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Manufacturer entity)
        {
            RemoveByPrefix(NopDiscountDefaults.DiscountManufacturerIdsPrefixCacheKey);
        }
    }
}
