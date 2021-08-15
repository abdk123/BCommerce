using Bwr.Core.Domain.Shipping;
using Bwr.Services.Caching;

namespace Bwr.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a warehouse cache event consumer
    /// </summary>
    public partial class WarehouseCacheEventConsumer : CacheEventConsumer<Warehouse>
    {
        protected override void ClearCache(Warehouse entity)
        {
            Remove(NopShippingDefaults.WarehousesAllCacheKey);
        }
    }
}
