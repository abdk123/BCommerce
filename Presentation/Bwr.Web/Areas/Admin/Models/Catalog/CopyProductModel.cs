using Bwr.Web.Framework.Mvc.ModelBinding;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a copy product model
    /// </summary>
    public partial class CopyProductModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Catalog.Products.Copy.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Copy.CopyImages")]
        public bool CopyImages { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Copy.Published")]
        public bool Published { get; set; }

        #endregion
    }
}