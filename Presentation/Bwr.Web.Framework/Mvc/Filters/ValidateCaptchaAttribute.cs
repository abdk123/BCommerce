using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Bwr.Core;
using Bwr.Core.Domain.Security;
using Bwr.Data;
using Bwr.Services.Logging;
using Bwr.Web.Framework.Security.Captcha;

namespace Bwr.Web.Framework.Mvc.Filters
{
    /// <summary>
    /// Represents a filter attribute enabling CAPTCHA validation
    /// </summary>
    public sealed class ValidateCaptchaAttribute : TypeFilterAttribute
    {
        #region Ctor

        /// <summary>
        /// Create instance of the filter attribute 
        /// </summary>
        /// <param name="actionParameterName">The name of the action parameter to which the result will be passed</param>
        public ValidateCaptchaAttribute(string actionParameterName = "captchaValid") : base(typeof(ValidateCaptchaFilter))
        {
            Arguments = new object[] { actionParameterName };
        }

        #endregion

        #region Nested filter

        /// <summary>
        /// Represents a filter enabling CAPTCHA validation
        /// </summary>
        private class ValidateCaptchaFilter : IActionFilter
        {
            #region Constants

            private const string RESPONSE_FIELD_KEY = "recaptcha_response_field";
            private const string G_RESPONSE_FIELD_KEY = "g-recaptcha-response";

            #endregion

            #region Fields

            private readonly string _actionParameterName;
            private readonly CaptchaHttpClient _captchaHttpClient;
            private readonly CaptchaSettings _captchaSettings;
            private readonly ILogger _logger;
            private readonly IWorkContext _workContext;

            #endregion

            #region Ctor

            public ValidateCaptchaFilter(string actionParameterName,
                CaptchaHttpClient captchaHttpClient,
                CaptchaSettings captchaSettings,
                ILogger logger,
                IWorkContext workContext)
            {
                _actionParameterName = actionParameterName;
                _captchaHttpClient = captchaHttpClient;
                _captchaSettings = captchaSettings;
                _logger = logger;
                _workContext = workContext;
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Validate CAPTCHA
            /// </summary>
            /// <param name="context">A context for action filters</param>
            /// <returns>True if CAPTCHA is valid; otherwise false</returns>
            protected bool ValidateCaptcha(ActionExecutingContext context)
            {
                var isValid = false;

                //get form values
                var captchaResponseValue = context.HttpContext.Request.Form[RESPONSE_FIELD_KEY];
                var gCaptchaResponseValue = context.HttpContext.Request.Form[G_RESPONSE_FIELD_KEY];

                if (!StringValues.IsNullOrEmpty(captchaResponseValue) || !StringValues.IsNullOrEmpty(gCaptchaResponseValue))
                {
                    //validate request
                    try
                    {
                        var value = !StringValues.IsNullOrEmpty(captchaResponseValue) ? captchaResponseValue : gCaptchaResponseValue;
                        var response = _captchaHttpClient.ValidateCaptchaAsync(value).Result;

                        switch (_captchaSettings.CaptchaType)
                        {
                            case CaptchaType.CheckBoxReCaptchaV2:
                                isValid = response.IsValid;
                                break;
                            case CaptchaType.ReCaptchaV3:
                                isValid = response.IsValid &&
                                            response.Action == context.RouteData.Values["action"].ToString() &&
                                              response.Score > _captchaSettings.ReCaptchaV3ScoreThreshold;
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.Error("Error occurred on CAPTCHA validation", exception, _workContext.CurrentCustomer);
                    }
                }

                return isValid;
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called before the action executes, after model binding is complete
            /// </summary>
            /// <param name="context">A context for action filters</param>
            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));

                if (!DataSettingsManager.DatabaseIsInstalled)
                    return;

                //whether CAPTCHA is enabled
                if (_captchaSettings.Enabled && context.HttpContext?.Request != null)
                {
                    //push the validation result as an action parameter
                    context.ActionArguments[_actionParameterName] = ValidateCaptcha(context);
                }
                else
                    context.ActionArguments[_actionParameterName] = false;

            }

            /// <summary>
            /// Called after the action executes, before the action result
            /// </summary>
            /// <param name="context">A context for action filters</param>
            public void OnActionExecuted(ActionExecutedContext context)
            {
                //do nothing
            }

            #endregion
        }

        #endregion
    }
}