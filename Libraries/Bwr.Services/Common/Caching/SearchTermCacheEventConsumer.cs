using Bwr.Core.Domain.Common;
using Bwr.Services.Caching;

namespace Bwr.Services.Common.Caching
{
    /// <summary>
    /// Represents a search term cache event consumer
    /// </summary>
    public partial class SearchTermCacheEventConsumer : CacheEventConsumer<SearchTerm>
    {
    }
}
