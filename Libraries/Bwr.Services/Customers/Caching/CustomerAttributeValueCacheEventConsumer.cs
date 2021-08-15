using Bwr.Core.Domain.Customers;
using Bwr.Services.Caching;

namespace Bwr.Services.Customers.Caching
{
    /// <summary>
    /// Represents a customer attribute value cache event consumer
    /// </summary>
    public partial class CustomerAttributeValueCacheEventConsumer : CacheEventConsumer<CustomerAttributeValue>
    {
        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(CustomerAttributeValue entity)
        {
            Remove(NopCustomerServicesDefaults.CustomerAttributesAllCacheKey);
            Remove(_cacheKeyService.PrepareKey(NopCustomerServicesDefaults.CustomerAttributeValuesAllCacheKey, entity.CustomerAttributeId));
        }
    }
}