﻿using FluentValidation;
using Bwr.Core;
using Bwr.Core.Domain.Catalog;
using Bwr.Data;
using Bwr.Services.Localization;
using Bwr.Web.Areas.Admin.Models.Catalog;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Catalog
{
    public partial class ProductReviewValidator : BaseNopValidator<ProductReviewModel>
    {
        public ProductReviewValidator(ILocalizationService localizationService, INopDataProvider dataProvider, IWorkContext workContext)
        {
            var isLoggedInAsVendor = workContext.CurrentVendor != null;
            //vendor can edit "Reply text" only
            if (!isLoggedInAsVendor)
            {
                RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.Title.Required"));
                RuleFor(x => x.ReviewText).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.ReviewText.Required"));
            }

            SetDatabaseValidationRules<ProductReview>(dataProvider);
        }
    }
}