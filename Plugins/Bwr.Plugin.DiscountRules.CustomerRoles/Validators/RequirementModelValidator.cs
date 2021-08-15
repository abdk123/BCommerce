using FluentValidation;
using Bwr.Plugin.DiscountRules.CustomerRoles.Models;
using Bwr.Services.Localization;
using Bwr.Web.Framework.Validators;

namespace Bwr.Plugin.DiscountRules.CustomerRoles.Validators
{
    /// <summary>
    /// Represents an <see cref="RequirementModel"/> validator.
    /// </summary>
    public class RequirementModelValidator : BaseNopValidator<RequirementModel>
    {
        public RequirementModelValidator(ILocalizationService localizationService)
        {
            RuleFor(model => model.DiscountId)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.DiscountRules.CustomerRoles.Fields.DiscountId.Required"));
            RuleFor(model => model.CustomerRoleId)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Plugins.DiscountRules.CustomerRoles.Fields.CustomerRoleId.Required"));
        }
    }
}
