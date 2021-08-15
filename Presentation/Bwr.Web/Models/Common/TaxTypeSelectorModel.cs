using Bwr.Core.Domain.Tax;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.Common
{
    public partial class TaxTypeSelectorModel : BaseNopModel
    {
        public TaxDisplayType CurrentTaxType { get; set; }
    }
}