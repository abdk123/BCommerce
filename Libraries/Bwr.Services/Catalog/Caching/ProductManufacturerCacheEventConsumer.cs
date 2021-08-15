﻿using Bwr.Core.Domain.Catalog;
using Bwr.Services.Caching;

namespace Bwr.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product manufacturer cache event consumer
    /// </summary>
    public partial class ProductManufacturerCacheEventConsumer : CacheEventConsumer<ProductManufacturer>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ProductManufacturer entity)
        {
            var prefix = _cacheKeyService.PrepareKeyPrefix(NopCatalogDefaults.ProductManufacturersByProductPrefixCacheKey, entity.ProductId);
            RemoveByPrefix(prefix);
            
            prefix = _cacheKeyService.PrepareKeyPrefix(NopCatalogDefaults.ProductPricePrefixCacheKey, entity.ProductId);
            RemoveByPrefix(prefix);
        }
    }
}
