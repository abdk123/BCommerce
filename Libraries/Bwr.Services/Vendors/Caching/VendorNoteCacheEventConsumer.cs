using Bwr.Core.Domain.Vendors;
using Bwr.Services.Caching;

namespace Bwr.Services.Vendors.Caching
{
    /// <summary>
    /// Represents a vendor note cache event consumer
    /// </summary>
    public partial class VendorNoteCacheEventConsumer : CacheEventConsumer<VendorNote>
    {
    }
}
