using Bwr.Core.Domain.Directory;
using Bwr.Services.Caching;

namespace Bwr.Services.Directory.Caching
{
    /// <summary>
    /// Represents a currency cache event consumer
    /// </summary>
    public partial class CurrencyCacheEventConsumer : CacheEventConsumer<Currency>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Currency entity)
        {
            RemoveByPrefix(NopDirectoryDefaults.CurrenciesAllPrefixCacheKey);
        }
    }
}
