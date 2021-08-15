using Bwr.Core.Domain.Orders;
using Bwr.Services.Caching;

namespace Bwr.Services.Orders.Caching
{
    /// <summary>
    /// Represents a recurring payment cache event consumer
    /// </summary>
    public partial class RecurringPaymentCacheEventConsumer : CacheEventConsumer<RecurringPayment>
    { 
    }
}
