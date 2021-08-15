using Bwr.Core.Domain.Logging;
using Bwr.Services.Caching;

namespace Bwr.Services.Logging.Caching
{
    /// <summary>
    /// Represents an activity log cache event consumer
    /// </summary>
    public partial class ActivityLogCacheEventConsumer : CacheEventConsumer<ActivityLog>
    {
    }
}