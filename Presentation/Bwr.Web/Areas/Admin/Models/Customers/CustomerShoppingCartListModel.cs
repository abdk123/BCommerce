using Bwr.Web.Areas.Admin.Models.ShoppingCart;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer shopping cart list model
    /// </summary>
    public partial class CustomerShoppingCartListModel : BasePagedListModel<ShoppingCartItemModel>
    {
    }
}