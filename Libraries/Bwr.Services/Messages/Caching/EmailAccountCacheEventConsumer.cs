﻿using Bwr.Core.Domain.Messages;
using Bwr.Services.Caching;

namespace Bwr.Services.Messages.Caching
{
    /// <summary>
    /// Represents an email account cache event consumer
    /// </summary>
    public partial class EmailAccountCacheEventConsumer : CacheEventConsumer<EmailAccount>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(EmailAccount entity)
        {
            Remove(NopMessageDefaults.EmailAccountsAllCacheKey);
        }
    }
}
