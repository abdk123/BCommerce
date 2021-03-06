using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a currency exchange rate provider model
    /// </summary>
    public partial class CurrencyExchangeRateProviderModel : BaseNopModel
    {
        #region Ctor

        public CurrencyExchangeRateProviderModel()
        {
            ExchangeRates = new List<CurrencyExchangeRateModel>();
            ExchangeRateProviders = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.Configuration.Currencies.Fields.CurrencyRateAutoUpdateEnabled")]
        public bool AutoUpdateEnabled { get; set; }

        public IList<CurrencyExchangeRateModel> ExchangeRates { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Currencies.Fields.ExchangeRateProvider")]
        public string ExchangeRateProvider { get; set; }
        public IList<SelectListItem> ExchangeRateProviders { get; set; }

        #endregion
    }
}