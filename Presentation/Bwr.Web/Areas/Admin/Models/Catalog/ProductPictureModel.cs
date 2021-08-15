﻿using System.ComponentModel.DataAnnotations;
using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product picture model
    /// </summary>
    public partial class ProductPictureModel : BaseNopEntityModel
    {
        #region Properties

        public int ProductId { get; set; }

        [UIHint("Picture")]
        [NopResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
        public int PictureId { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.Picture")]
        public string PictureUrl { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideAltAttribute")]
        public string OverrideAltAttribute { get; set; }

        [NopResourceDisplayName("Admin.Catalog.Products.Pictures.Fields.OverrideTitleAttribute")]
        public string OverrideTitleAttribute { get; set; }

        #endregion
    }
}