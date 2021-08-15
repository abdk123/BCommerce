using Bwr.Core.Domain.Gdpr;
using Bwr.Services.Caching;

namespace Bwr.Services.Gdpr.Caching
{
    /// <summary>
    /// Represents a GDPR log cache event consumer
    /// </summary>
    public partial class GdprLogCacheEventConsumer : CacheEventConsumer<GdprLog>
    {
    }
}
