using Bwr.Core.Domain.Media;
using Bwr.Services.Caching;

namespace Bwr.Services.Media.Caching
{
    /// <summary>
    /// Represents a picture cache event consumer
    /// </summary>
    public partial class PictureCacheEventConsumer : CacheEventConsumer<Picture>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Picture entity)
        {
            RemoveByPrefix(NopMediaDefaults.ThumbsExistsPrefixCacheKey);
        }
    }
}
