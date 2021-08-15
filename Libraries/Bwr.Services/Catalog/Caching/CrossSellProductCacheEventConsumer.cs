using Bwr.Core.Domain.Catalog;
using Bwr.Services.Caching;

namespace Bwr.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a cross-sell product cache event consumer
    /// </summary>
    public partial class CrossSellProductCacheEventConsumer : CacheEventConsumer<CrossSellProduct>
    {
    }
}
