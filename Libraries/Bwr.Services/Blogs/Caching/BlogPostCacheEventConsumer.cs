using Bwr.Core.Domain.Blogs;
using Bwr.Services.Caching;

namespace Bwr.Services.Blogs.Caching
{
    /// <summary>
    /// Represents a blog post cache event consumer
    /// </summary>
    public partial class BlogPostCacheEventConsumer : CacheEventConsumer<BlogPost>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(BlogPost entity)
        {
            RemoveByPrefix(NopBlogsDefaults.BlogTagsPrefixCacheKey);
        }
    }
}