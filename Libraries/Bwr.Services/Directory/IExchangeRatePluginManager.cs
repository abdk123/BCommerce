using Bwr.Core.Domain.Customers;
using Bwr.Services.Plugins;

namespace Bwr.Services.Directory
{
    /// <summary>
    /// Represents an exchange rate plugin manager
    /// </summary>
    public partial interface IExchangeRatePluginManager : IPluginManager<IExchangeRateProvider>
    {
        /// <summary>
        /// Load primary active exchange rate provider
        /// </summary>
        /// <param name="customer">Filter by customer; pass null to load all plugins</param>
        /// <param name="storeId">Filter by store; pass 0 to load all plugins</param>
        /// <returns>Exchange rate provider</returns>
        IExchangeRateProvider LoadPrimaryPlugin(Customer customer = null, int storeId = 0);

        /// <summary>
        /// Check whether the passed exchange rate provider is active
        /// </summary>
        /// <param name="exchangeRateProvider">Exchange rate provider to check</param>
        /// <returns>Result</returns>
        bool IsPluginActive(IExchangeRateProvider exchangeRateProvider);
    }
}