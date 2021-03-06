using System;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a reward point model
    /// </summary>
    public partial class CustomerRewardPointsModel : BaseNopEntityModel
    {
        #region Properties

        public string StoreName { get; set; }

        public int Points { get; set; }

        public string PointsBalance { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? EndDate { get; set; }

        #endregion
    }
}