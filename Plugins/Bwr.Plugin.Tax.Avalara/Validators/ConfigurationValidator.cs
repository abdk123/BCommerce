//using FluentValidation;
//using Bwr.Plugin.Tax.Avalara.Models.Configuration;
//using Bwr.Services.Localization;
//using Bwr.Web.Framework.Validators;

//namespace Bwr.Plugin.Tax.Avalara.Validators
//{
//    /// <summary>
//    /// Represents configuration model validator
//    /// </summary>
//    public class ConfigurationValidator : BaseNopValidator<ConfigurationModel>
//    {
//        #region Ctor

//        public ConfigurationValidator(ILocalizationService localizationService)
//        {
//            RuleFor(model => model.AccountId)
//                .NotEmpty()
//                .WithMessage(localizationService.GetResource("Plugins.Tax.Avalara.Fields.AccountId.Required"));
//            RuleFor(model => model.LicenseKey)
//                .NotEmpty()
//                .WithMessage(localizationService.GetResource("Plugins.Tax.Avalara.Fields.LicenseKey.Required"));
//        }

//        #endregion
//    }
//}