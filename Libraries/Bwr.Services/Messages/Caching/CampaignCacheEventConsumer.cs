using Bwr.Core.Domain.Messages;
using Bwr.Services.Caching;

namespace Bwr.Services.Messages.Caching
{
    /// <summary>
    /// Represents a campaign cache event consumer
    /// </summary>
    public partial class CampaignCacheEventConsumer : CacheEventConsumer<Campaign>
    {
    }
}
