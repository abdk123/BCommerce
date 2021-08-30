﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Bwr.Web.Framework;
using Bwr.Web.Framework.Mvc.Routing;

namespace Bwr.Plugin.Widgets.FacebookPixel.Infrastructure
{
    /// <summary>
    /// Represents plugin route provider
    /// </summary>
    public class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute(FacebookPixelDefaults.ConfigurationRouteName, "Plugins/FacebookPixel/Configure",
                new { controller = "FacebookPixel", action = "Configure", area = AreaNames.Admin });
        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;
    }
}