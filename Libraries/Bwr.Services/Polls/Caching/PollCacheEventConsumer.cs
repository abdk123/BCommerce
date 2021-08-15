using Bwr.Core.Domain.Polls;
using Bwr.Services.Caching;

namespace Bwr.Services.Polls.Caching
{
    /// <summary>
    /// Represents a poll cache event consumer
    /// </summary>
    public partial class PollCacheEventConsumer : CacheEventConsumer<Poll>
    {
    }
}