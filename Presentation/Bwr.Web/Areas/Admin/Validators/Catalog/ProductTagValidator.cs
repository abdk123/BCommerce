using FluentValidation;
using Bwr.Core.Domain.Catalog;
using Bwr.Data;
using Bwr.Services.Localization;
using Bwr.Web.Areas.Admin.Models.Catalog;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductTagValidator : BaseNopValidator<ProductTagModel>
    {
        public ProductTagValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductTags.Fields.Name.Required"));

            SetDatabaseValidationRules<ProductTag>(dataProvider);
        }
    }
}