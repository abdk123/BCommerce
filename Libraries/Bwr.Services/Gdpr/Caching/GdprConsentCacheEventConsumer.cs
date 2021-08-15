using Bwr.Core.Domain.Gdpr;
using Bwr.Services.Caching;

namespace Bwr.Services.Gdpr.Caching
{
    /// <summary>
    /// Represents a GDPR consent cache event consumer
    /// </summary>
    public partial class GdprConsentCacheEventConsumer : CacheEventConsumer<GdprConsent>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(GdprConsent entity)
        {
            Remove(NopGdprDefaults.ConsentsAllCacheKey);
        }
    }
}