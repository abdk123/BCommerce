using Bwr.Core.Domain.Catalog;
using Bwr.Services.Caching;
using Bwr.Services.Orders;

namespace Bwr.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product cache event consumer
    /// </summary>
    public partial class ProductCacheEventConsumer : CacheEventConsumer<Product>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Product entity)
        {
            var prefix = _cacheKeyService.PrepareKeyPrefix(NopCatalogDefaults.ProductManufacturersByProductPrefixCacheKey, entity);
            RemoveByPrefix(prefix);

            Remove(NopCatalogDefaults.ProductsAllDisplayedOnHomepageCacheKey);
            RemoveByPrefix(NopCatalogDefaults.ProductsByIdsPrefixCacheKey);

            prefix = _cacheKeyService.PrepareKeyPrefix(NopCatalogDefaults.ProductPricePrefixCacheKey, entity);
            RemoveByPrefix(prefix);

            RemoveByPrefix(NopOrderDefaults.ShoppingCartPrefixCacheKey);
        }
    }
}
