using Bwr.Core.Domain.Orders;
using Bwr.Services.Caching;

namespace Bwr.Services.Orders.Caching
{
    /// <summary>
    /// Represents a order cache event consumer
    /// </summary>
    public partial class OrderCacheEventConsumer : CacheEventConsumer<Order>
    {
    }
}