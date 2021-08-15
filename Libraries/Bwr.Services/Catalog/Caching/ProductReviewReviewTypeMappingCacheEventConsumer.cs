﻿using Bwr.Core.Domain.Catalog;
using Bwr.Services.Caching;

namespace Bwr.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product review review type cache event consumer
    /// </summary>
    public partial class ProductReviewReviewTypeMappingCacheEventConsumer : CacheEventConsumer<ProductReviewReviewTypeMapping>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ProductReviewReviewTypeMapping entity)
        {
            Remove(NopCatalogDefaults.ReviewTypeAllCacheKey);

            var cacheKey = _cacheKeyService.PrepareKey(NopCatalogDefaults.ProductReviewReviewTypeMappingAllCacheKey, entity.ProductReviewId);
            Remove(cacheKey);
        }
    }
}
