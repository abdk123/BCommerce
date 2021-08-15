using Bwr.Core.Domain.Catalog;
using Bwr.Services.Caching;

namespace Bwr.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a product review helpfulness cache event consumer
    /// </summary>
    public partial class ProductReviewHelpfulnessCacheEventConsumer : CacheEventConsumer<ProductReviewHelpfulness>
    {
    }
}
