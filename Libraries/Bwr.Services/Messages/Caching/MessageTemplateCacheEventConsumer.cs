﻿using Bwr.Core.Domain.Messages;
using Bwr.Services.Caching;

namespace Bwr.Services.Messages.Caching
{
    /// <summary>
    /// Represents a message template cache event consumer
    /// </summary>
    public partial class MessageTemplateCacheEventConsumer : CacheEventConsumer<MessageTemplate>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(MessageTemplate entity)
        {
            RemoveByPrefix(NopMessageDefaults.MessageTemplatesAllPrefixCacheKey);
            var prefix = _cacheKeyService.PrepareKeyPrefix(NopMessageDefaults.MessageTemplatesByNamePrefixCacheKey, entity.Name);
            RemoveByPrefix(prefix);
        }
    }
}
