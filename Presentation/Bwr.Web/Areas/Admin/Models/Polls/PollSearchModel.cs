﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Web.Areas.Admin.Models.Polls
{
    /// <summary>
    /// Represents a poll search model
    /// </summary>
    public partial class PollSearchModel : BaseSearchModel
    {
        #region Ctor

        public PollSearchModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Admin.ContentManagement.Polls.List.SearchStore")]
        public int SearchStoreId { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}