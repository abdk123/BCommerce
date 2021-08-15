﻿using Bwr.Core.Domain.Security;
using Bwr.Services.Caching;

namespace Bwr.Services.Security.Caching
{
    /// <summary>
    /// Represents a permission record cache event consumer
    /// </summary>
    public partial class PermissionRecordCacheEventConsumer : CacheEventConsumer<PermissionRecord>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(PermissionRecord entity)
        {
            var prefix = _cacheKeyService.PrepareKeyPrefix(NopSecurityDefaults.PermissionsAllowedPrefixCacheKey, entity.SystemName);
            RemoveByPrefix(prefix);
            RemoveByPrefix(NopSecurityDefaults.PermissionsAllByCustomerRoleIdPrefixCacheKey);
        }
    }
}
