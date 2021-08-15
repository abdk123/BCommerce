using Bwr.Core.Domain.Forums;
using Bwr.Services.Caching;

namespace Bwr.Services.Forums.Caching
{
    /// <summary>
    /// Represents a forum group cache event consumer
    /// </summary>
    public partial class ForumGroupCacheEventConsumer : CacheEventConsumer<ForumGroup>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(ForumGroup entity)
        {
            Remove(NopForumDefaults.ForumGroupAllCacheKey);
            var cacheKey = _cacheKeyService.PrepareKey(NopForumDefaults.ForumAllByForumGroupIdCacheKey, entity);
            Remove(cacheKey);
        }
    }
}
