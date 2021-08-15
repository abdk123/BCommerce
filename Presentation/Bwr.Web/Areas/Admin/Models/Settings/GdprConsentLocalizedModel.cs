﻿using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a GDPR consent localized model
    /// </summary>
    public partial class GdprConsentLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.Message")]
        public string Message { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Gdpr.Consent.RequiredMessage")]
        public string RequiredMessage { get; set; }
    }
}
