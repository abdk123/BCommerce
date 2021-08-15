﻿using Bwr.Core.Domain.Common;
using Bwr.Services.Caching;

namespace Bwr.Services.Common.Caching
{
    /// <summary>
    /// Represents a address attribute value cache event consumer
    /// </summary>
    public partial class AddressAttributeValueCacheEventConsumer : CacheEventConsumer<AddressAttributeValue>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(AddressAttributeValue entity)
        {
            Remove(NopCommonDefaults.AddressAttributesAllCacheKey);

            var cacheKey = _cacheKeyService.PrepareKey(NopCommonDefaults.AddressAttributeValuesAllCacheKey, entity.AddressAttributeId);
            Remove(cacheKey);
        }
    }
}
