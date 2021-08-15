using FluentValidation;
using Bwr.Core.Domain.Orders;
using Bwr.Data;
using Bwr.Services.Localization;
using Bwr.Web.Areas.Admin.Models.Orders;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Orders
{
    public partial class ReturnRequestActionValidator : BaseNopValidator<ReturnRequestActionModel>
    {
        public ReturnRequestActionValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.Order.ReturnRequestActions.Name.Required"));

            SetDatabaseValidationRules<ReturnRequestAction>(dataProvider);
        }
    }
}