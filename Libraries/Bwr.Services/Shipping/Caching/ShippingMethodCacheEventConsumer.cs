using Bwr.Core.Domain.Shipping;
using Bwr.Services.Caching;

namespace Bwr.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a shipping method cache event consumer
    /// </summary>
    public partial class ShippingMethodCacheEventConsumer : CacheEventConsumer<ShippingMethod>
    {
        protected override void ClearCache(ShippingMethod entity)
        {
            RemoveByPrefix(NopShippingDefaults.ShippingMethodsAllPrefixCacheKey);
        }
    }
}
