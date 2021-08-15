﻿using Bwr.Core.Domain.Orders;
using Bwr.Services.Caching;

namespace Bwr.Services.Orders.Caching
{
    /// <summary>
    /// Represents an order note cache event consumer
    /// </summary>
    public partial class OrderNoteCacheEventConsumer : CacheEventConsumer<OrderNote>
    {
    }
}
