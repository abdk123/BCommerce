﻿using Bwr.Core.Domain.Catalog;
using Bwr.Services.Caching;

namespace Bwr.Services.Catalog.Caching
{
    /// <summary>
    /// Represents a stock quantity change entry cache event consumer
    /// </summary>
    public partial class StockQuantityHistoryCacheEventConsumer : CacheEventConsumer<StockQuantityHistory>
    {
    }
}
