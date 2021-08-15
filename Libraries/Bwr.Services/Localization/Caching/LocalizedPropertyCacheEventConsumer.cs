using Bwr.Core.Domain.Localization;
using Bwr.Services.Caching;

namespace Bwr.Services.Localization.Caching
{
    /// <summary>
    /// Represents a localized property cache event consumer
    /// </summary>
    public partial class LocalizedPropertyCacheEventConsumer : CacheEventConsumer<LocalizedProperty>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(LocalizedProperty entity)
        {
            Remove(NopLocalizationDefaults.LocalizedPropertyAllCacheKey);

            var cacheKey = _cacheKeyService.PrepareKey(NopLocalizationDefaults.LocalizedPropertyCacheKey,
                entity.LanguageId, entity.EntityId, entity.LocaleKeyGroup, entity.LocaleKey);

            Remove(cacheKey);
        }
    }
}
