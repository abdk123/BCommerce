using Bwr.Core.Caching;

namespace Bwr.Services.Tax
{
    /// <summary>
    /// Represents default values related to tax services
    /// </summary>
    public static partial class NopTaxDefaults
    {
        #region Caching defaults

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static CacheKey TaxCategoriesAllCacheKey => new CacheKey("Bwr.taxcategory.all");

        #endregion
    }
}