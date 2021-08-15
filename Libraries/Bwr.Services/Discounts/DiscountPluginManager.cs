using Bwr.Services.Customers;
using Bwr.Services.Plugins;

namespace Bwr.Services.Discounts
{
    /// <summary>
    /// Represents a discount requirement plugin manager implementation
    /// </summary>
    public partial class DiscountPluginManager : PluginManager<IDiscountRequirementRule>, IDiscountPluginManager
    {
        #region Ctor

        public DiscountPluginManager(ICustomerService customerService,
            IPluginService pluginService) : base(customerService, pluginService)
        {
        }

        #endregion
    }
}