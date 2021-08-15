using Bwr.Core.Domain.Forums;
using Bwr.Services.Caching;

namespace Bwr.Services.Forums.Caching
{
    /// <summary>
    /// Represents a private message cache event consumer
    /// </summary>
    public partial class PrivateMessageCacheEventConsumer : CacheEventConsumer<PrivateMessage>
    {
    }
}
