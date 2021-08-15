using FluentValidation;
using Bwr.Services.Localization;
using Bwr.Web.Framework.Validators;
using Bwr.Web.Models.Vendors;

namespace Bwr.Web.Validators.Vendors
{
    public partial class VendorInfoValidator : BaseNopValidator<VendorInfoModel>
    {
        public VendorInfoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Name.Required"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.VendorInfo.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }
    }
}