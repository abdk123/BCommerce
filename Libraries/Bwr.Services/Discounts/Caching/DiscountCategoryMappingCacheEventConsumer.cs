using Bwr.Core.Domain.Discounts;
using Bwr.Services.Caching;

namespace Bwr.Services.Discounts.Caching
{
    /// <summary>
    /// Represents a discount-category mapping cache event consumer
    /// </summary>
    public partial class DiscountCategoryMappingCacheEventConsumer : CacheEventConsumer<DiscountCategoryMapping>
    {
    }
}