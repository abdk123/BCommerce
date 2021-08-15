using Bwr.Core.Domain.Logging;
using Bwr.Services.Caching;

namespace Bwr.Services.Logging.Caching
{
    /// <summary>
    /// Represents a log cache event consumer
    /// </summary>
    public partial class LogCacheEventConsumer : CacheEventConsumer<Log>
    {
    }
}
