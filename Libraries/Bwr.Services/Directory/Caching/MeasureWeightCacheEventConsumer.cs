using Bwr.Core.Domain.Directory;
using Bwr.Services.Caching;

namespace Bwr.Services.Directory.Caching
{
    /// <summary>
    /// Represents a measure weight cache event consumer
    /// </summary>
    public partial class MeasureWeightCacheEventConsumer : CacheEventConsumer<MeasureWeight>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(MeasureWeight entity)
        {
            Remove(NopDirectoryDefaults.MeasureWeightsAllCacheKey);
        }
    }
}
