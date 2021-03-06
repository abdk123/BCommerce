using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a product model to add to the customer role 
    /// </summary>
    public partial class AddProductToCustomerRoleModel : BaseNopEntityModel
    {
        #region Properties

        public int AssociatedToProductId { get; set; }

        #endregion
    }
}