using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Plugin.Widgets.FacebookPixel.Models
{
    /// <summary>
    /// Represents a custom event search model
    /// </summary>
    public partial class CustomEventSearchModel : BaseSearchModel
    {
        #region Ctor

        public CustomEventSearchModel()
        {
            AddCustomEvent = new CustomEventModel();
        }

        #endregion

        #region Properties

        public int ConfigurationId { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.FacebookPixel.Configuration.CustomEvents.Search.WidgetZone")]
        public string WidgetZone { get; set; }

        public CustomEventModel AddCustomEvent { get; set; }

        #endregion
    }
}