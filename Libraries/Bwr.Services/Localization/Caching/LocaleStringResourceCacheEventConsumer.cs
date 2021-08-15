using Bwr.Core.Domain.Localization;
using Bwr.Services.Caching;

namespace Bwr.Services.Localization.Caching
{
    /// <summary>
    /// Represents a locale string resource cache event consumer
    /// </summary>
    public partial class LocaleStringResourceCacheEventConsumer : CacheEventConsumer<LocaleStringResource>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(LocaleStringResource entity)
        {
            RemoveByPrefix(NopLocalizationDefaults.LocaleStringResourcesPrefixCacheKey);
        }
    }
}
