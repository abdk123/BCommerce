using FluentValidation;
using Bwr.Services.Localization;
using Bwr.Web.Framework.Validators;
using Bwr.Web.Models.Customer;

namespace Bwr.Web.Validators.Customer
{
    public partial class GiftCardValidator : BaseNopValidator<CheckGiftCardBalanceModel>
    {
        public GiftCardValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.GiftCardCode).NotEmpty().WithMessage(localizationService.GetResource("CheckGiftCardBalance.GiftCardCouponCode.Empty"));            
        }
    }
}
