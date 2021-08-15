using Bwr.Core.Domain.Polls;
using Bwr.Services.Caching;

namespace Bwr.Services.Polls.Caching
{
    /// <summary>
    /// Represents a poll voting record cache event consumer
    /// </summary>
    public partial class PollVotingRecordCacheEventConsumer : CacheEventConsumer<PollVotingRecord>
    {
    }
}