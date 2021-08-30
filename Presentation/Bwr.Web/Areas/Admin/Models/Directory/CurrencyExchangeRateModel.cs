﻿using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a currency exchange rate model
    /// </summary>
    public partial class CurrencyExchangeRateModel : BaseNopModel
    {
        #region Properties

        public string CurrencyCode { get; set; }

        public decimal Rate { get; set; }

        #endregion
    }
}