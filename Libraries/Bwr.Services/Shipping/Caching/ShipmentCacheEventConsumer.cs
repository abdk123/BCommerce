using Bwr.Core.Domain.Shipping;
using Bwr.Services.Caching;

namespace Bwr.Services.Shipping.Caching
{
    /// <summary>
    /// Represents a shipment cache event consumer
    /// </summary>
    public partial class ShipmentCacheEventConsumer : CacheEventConsumer<Shipment>
    {
    }
}