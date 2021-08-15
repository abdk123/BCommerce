using Bwr.Core.Domain.Forums;
using Bwr.Services.Caching;

namespace Bwr.Services.Forums.Caching
{
    /// <summary>
    /// Represents a forum subscription cache event consumer
    /// </summary>
    public partial class ForumSubscriptionCacheEventConsumer : CacheEventConsumer<ForumSubscription>
    {
    }
}
