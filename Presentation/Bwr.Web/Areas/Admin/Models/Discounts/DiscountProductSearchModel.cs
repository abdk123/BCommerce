using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount product search model
    /// </summary>
    public partial class DiscountProductSearchModel : BaseSearchModel
    {
        #region Properties

        public int DiscountId { get; set; }

        #endregion
    }
}