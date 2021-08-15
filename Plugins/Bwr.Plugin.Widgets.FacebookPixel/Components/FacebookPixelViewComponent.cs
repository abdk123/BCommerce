using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Bwr.Plugin.Widgets.FacebookPixel.Services;
using Bwr.Web.Framework.Components;
using Bwr.Web.Framework.Infrastructure;

namespace Bwr.Plugin.Widgets.FacebookPixel.Components
{
    /// <summary>
    /// Represents Facebook Pixel view component
    /// </summary>
    [ViewComponent(Name = FacebookPixelDefaults.VIEW_COMPONENT)]
    public class FacebookPixelViewComponent : NopViewComponent
    {
        #region Fields

        private readonly FacebookPixelService _facebookPixelService;

        #endregion

        #region Ctor

        public FacebookPixelViewComponent(FacebookPixelService facebookPixelService)
        {
            _facebookPixelService = facebookPixelService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <param name="additionalData">Additional data</param>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var script = widgetZone != PublicWidgetZones.HeadHtmlTag
                ? _facebookPixelService.PrepareCustomEventsScript(widgetZone)
                : _facebookPixelService.PrepareScript();

            return new HtmlContentViewComponentResult(new HtmlString(script ?? string.Empty));
        }

        #endregion
    }
}