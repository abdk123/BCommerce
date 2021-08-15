using System;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Areas.Admin.Models.Home
{
    /// <summary>
    /// Represents a bwire news details model
    /// </summary>
    public partial class NopCommerceNewsDetailsModel : BaseNopModel
    {
        #region Properties

        public string Title { get; set; }

        public string Url { get; set; }

        public string Summary { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        #endregion
    }
}