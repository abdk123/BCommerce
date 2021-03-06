using System.Collections.Generic;
using Bwr.Core;
using Bwr.Services.Authentication.External;
using Bwr.Services.Configuration;
using Bwr.Services.Localization;
using Bwr.Services.Plugins;

namespace Bwr.Plugin.ExternalAuth.Facebook
{
    /// <summary>
    /// Represents method for the authentication with Facebook account
    /// </summary>
    public class FacebookAuthenticationMethod : BasePlugin, IExternalAuthenticationMethod
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public FacebookAuthenticationMethod(ILocalizationService localizationService,
            ISettingService settingService,
            IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _settingService = settingService;
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/FacebookAuthentication/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return FacebookAuthenticationDefaults.VIEW_COMPONENT_NAME;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {
            //settings
            _settingService.SaveSetting(new FacebookExternalAuthSettings());

            //locales
            _localizationService.AddPluginLocaleResource(new Dictionary<string, string>
            {
                ["Plugins.ExternalAuth.Facebook.ClientKeyIdentifier"] = "App ID/API Key",
                ["Plugins.ExternalAuth.Facebook.ClientKeyIdentifier.Hint"] = "Enter your app ID/API key here. You can find it on your FaceBook application page.",
                ["Plugins.ExternalAuth.Facebook.ClientSecret"] = "App Secret",
                ["Plugins.ExternalAuth.Facebook.ClientSecret.Hint"] = "Enter your app secret here. You can find it on your FaceBook application page.",
                ["Plugins.ExternalAuth.Facebook.Instructions"] = "<p>To configure authentication with Facebook, please follow these steps:<br/><br/><ol><li>Navigate to the <a href=\"https://developers.facebook.com/apps\" target =\"_blank\" > Facebook for Developers</a> page and sign in. If you don't already have a Facebook account, use the <b>Sign up for Facebook</b> link on the login page to create one.</li><li>Tap the <b>+ Add a New App button</b> in the upper right corner to create a new App ID. (If this is your first app with Facebook, the text of the button will be <b>Create a New App</b>.)</li><li>Fill out the form and tap the <b>Create App ID button</b>.</li><li>The <b>Product Setup</b> page is displayed, letting you select the features for your new app. Click <b>Get Started</b> on <b>Facebook Login</b>.</li><li>Click the <b>Settings</b> link in the menu at the left, you are presented with the <b>Client OAuth Settings</b> page with some defaults already set.</li><li>Enter \"{0:s}signin-facebook\" into the <b>Valid OAuth Redirect URIs</b> field.</li><li>Click <b>Save Changes</b>.</li><li>Click the <b>Dashboard</b> link in the left navigation.</li><li>Copy your App ID and App secret below.</li></ol><br/><br/></p>"
            });

            base.Install();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<FacebookExternalAuthSettings>();

            //locales
            _localizationService.DeletePluginLocaleResources("Plugins.ExternalAuth.Facebook");

            base.Uninstall();
        }

        #endregion
    }
}