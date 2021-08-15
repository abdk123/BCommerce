using Bwr.Core.Caching;

namespace Bwr.Services.Stores
{
    /// <summary>
    /// Represents default values related to stores services
    /// </summary>
    public static partial class NopStoreDefaults
    {
        #region Caching defaults

        #region Store mappings

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : entity ID
        /// {1} : entity name
        /// </remarks>
        public static CacheKey StoreMappingIdsByEntityIdNameCacheKey => new CacheKey("Bwr.storemapping.ids.entityid-name-{0}-{1}");

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : entity ID
        /// {1} : entity name
        /// </remarks>
        public static CacheKey StoreMappingsByEntityIdNameCacheKey => new CacheKey("Bwr.storemapping.entityid-name-{0}-{1}");

        #endregion

        #region Stores

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static CacheKey StoresAllCacheKey => new CacheKey("Bwr.stores.all");

        #endregion

        #endregion
    }
}