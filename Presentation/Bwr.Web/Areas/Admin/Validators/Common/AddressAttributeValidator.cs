using FluentValidation;
using Bwr.Core.Domain.Common;
using Bwr.Data;
using Bwr.Services.Localization;
using Bwr.Web.Areas.Admin.Models.Common;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Common
{
    public partial class AddressAttributeValidator : BaseNopValidator<AddressAttributeModel>
    {
        public AddressAttributeValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Address.AddressAttributes.Fields.Name.Required"));

            SetDatabaseValidationRules<AddressAttribute>(dataProvider);
        }
    }
}