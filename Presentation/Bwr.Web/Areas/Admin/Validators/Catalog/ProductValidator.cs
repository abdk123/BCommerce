using FluentValidation;
using Bwr.Core.Domain.Catalog;
using Bwr.Data;
using Bwr.Services.Localization;
using Bwr.Services.Seo;
using Bwr.Web.Areas.Admin.Models.Catalog;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductValidator : BaseNopValidator<ProductModel>
    {
        public ProductValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.Fields.Name.Required"));
            
            RuleFor(x => x.SeName)
                .Length(0, NopSeoDefaults.SearchEngineNameLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.SearchEngineNameLength));
            
            RuleFor(x => x.RentalPriceLength)
                .GreaterThan(0)
                .WithMessage(localizationService.GetResource("Admin.Catalog.Products.Fields.RentalPriceLength.ShouldBeGreaterThanZero"))
                .When(x => x.IsRental);

            SetDatabaseValidationRules<Product>(dataProvider);
        }
    }
}