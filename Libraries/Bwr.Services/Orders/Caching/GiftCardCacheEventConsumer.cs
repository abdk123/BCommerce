using Bwr.Core.Domain.Orders;
using Bwr.Services.Caching;

namespace Bwr.Services.Orders.Caching
{
    /// <summary>
    /// Represents a gift card cache event consumer
    /// </summary>
    public partial class GiftCardCacheEventConsumer : CacheEventConsumer<GiftCard>
    {
    }
}
