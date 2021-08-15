﻿using System.Collections.Generic;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a related product model to add to the product
    /// </summary>
    public partial class AddRelatedProductModel : BaseNopModel
    {
        #region Ctor

        public AddRelatedProductModel()
        {
            SelectedProductIds = new List<int>();
        }
        #endregion

        #region Properties

        public int ProductId { get; set; }

        public IList<int> SelectedProductIds { get; set; }

        #endregion
    }
}