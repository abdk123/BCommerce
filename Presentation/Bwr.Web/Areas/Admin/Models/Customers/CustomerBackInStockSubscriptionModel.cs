﻿using System;
using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer back in stock subscription model
    /// </summary>
    public partial class CustomerBackInStockSubscriptionModel : BaseNopEntityModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Store")]
        public string StoreName { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Product")]
        public int ProductId { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.Product")]
        public string ProductName { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.BackInStockSubscriptions.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}