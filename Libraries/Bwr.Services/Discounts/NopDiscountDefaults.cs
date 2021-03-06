using Bwr.Core.Caching;

namespace Bwr.Services.Discounts
{
    /// <summary>
    /// Represents default values related to discounts services
    /// </summary>
    public static partial class NopDiscountDefaults
    {
        /// <summary>
        /// Gets the query parameter name to retrieve discount coupon code from URL
        /// </summary>
        public static string DiscountCouponQueryParameter => "discountcoupon";

        #region Caching defaults

        /// <summary>
        /// Key for discount requirement of a certain discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// </remarks>
        public static CacheKey DiscountRequirementModelCacheKey => new CacheKey("Bwr.discounts.requirements-{0}");

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// {1} : coupon code
        /// {2} : discount name
        /// </remarks>
        public static CacheKey DiscountAllCacheKey => new CacheKey("Bwr.discounts.all-{0}-{1}-{2}", DiscountAllPrefixCacheKey);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string DiscountAllPrefixCacheKey => "Bwr.discounts.all";

        /// <summary>
        /// Key for category IDs of a discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey DiscountCategoryIdsModelCacheKey => new CacheKey("Bwr.discounts.categoryids-{0}-{1}-{2}", DiscountCategoryIdsByDiscountPrefixCacheKey, DiscountCategoryIdsPrefixCacheKey);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// </remarks>
        public static string DiscountCategoryIdsByDiscountPrefixCacheKey => "Bwr.discounts.categoryids-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string DiscountCategoryIdsPrefixCacheKey => "Bwr.discounts.categoryids";

        /// <summary>
        /// Key for manufacturer IDs of a discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey DiscountManufacturerIdsModelCacheKey => new CacheKey("Bwr.discounts.manufacturerids-{0}-{1}-{2}", DiscountManufacturerIdsByDiscountPrefixCacheKey, DiscountManufacturerIdsPrefixCacheKey);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// </remarks>
        public static string DiscountManufacturerIdsByDiscountPrefixCacheKey => "Bwr.discounts.manufacturerids-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string DiscountManufacturerIdsPrefixCacheKey => "Bwr.discounts.manufacturerids";

        #endregion
    }
}