using FluentValidation;
using Bwr.Plugin.Widgets.FacebookPixel.Models;
using Bwr.Services.Localization;
using Bwr.Web.Framework.Validators;

namespace Bwr.Plugin.Widgets.FacebookPixel.Validators
{
    /// <summary>
    /// Represents configuration model validator
    /// </summary>
    public class ConfigurationValidator : BaseNopValidator<FacebookPixelModel>
    {
        #region Ctor

        public ConfigurationValidator(ILocalizationService localizationService)
        {
            //set validation rules
            RuleFor(model => model.PixelId)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.Widgets.FacebookPixel.Configuration.Fields.PixelId.Required"));
            RuleFor(model => model.UseAdvancedMatching)
                .NotEqual(true)
                .WithMessage(localizationService.GetResource("Plugins.Widgets.FacebookPixel.Configuration.Fields.UseAdvancedMatching.Forbidden"))
                .When(model => model.PassUserProperties);
            RuleFor(model => model.PassUserProperties)
                .NotEqual(true)
                .WithMessage(localizationService.GetResource("Plugins.Widgets.FacebookPixel.Configuration.Fields.PassUserProperties.Forbidden"))
                .When(model => model.UseAdvancedMatching);
        }

        #endregion
    }
}