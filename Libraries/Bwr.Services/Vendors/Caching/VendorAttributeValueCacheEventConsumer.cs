using Bwr.Core.Domain.Vendors;
using Bwr.Services.Caching;

namespace Bwr.Services.Vendors.Caching
{
    /// <summary>
    /// Represents a vendor attribute value cache event consumer
    /// </summary>
    public partial class VendorAttributeValueCacheEventConsumer : CacheEventConsumer<VendorAttributeValue>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(VendorAttributeValue entity)
        {
            var cacheKey = _cacheKeyService.PrepareKey(NopVendorDefaults.VendorAttributeValuesAllCacheKey, entity.VendorAttributeId);

            Remove(cacheKey);
        }
    }
}
