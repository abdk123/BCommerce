using System.Collections.Generic;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.Common
{
    public partial class CurrencySelectorModel : BaseNopModel
    {
        public CurrencySelectorModel()
        {
            AvailableCurrencies = new List<CurrencyModel>();
        }

        public IList<CurrencyModel> AvailableCurrencies { get; set; }

        public int CurrentCurrencyId { get; set; }
    }
}