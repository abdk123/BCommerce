using FluentValidation;
using Bwr.Core.Domain.Topics;
using Bwr.Data;
using Bwr.Services.Localization;
using Bwr.Services.Seo;
using Bwr.Web.Areas.Admin.Models.Topics;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Topics
{
    public partial class TopicValidator : BaseNopValidator<TopicModel>
    {
        public TopicValidator(ILocalizationService localizationService, INopDataProvider dataProvider)
        {
            RuleFor(x => x.SeName)
                .Length(0, NopSeoDefaults.ForumTopicLength)
                .WithMessage(string.Format(localizationService.GetResource("Admin.SEO.SeName.MaxLengthValidation"), NopSeoDefaults.ForumTopicLength));

            RuleFor(x => x.Password)
                .NotEmpty()
                .When(x => x.IsPasswordProtected)
                .WithMessage(localizationService.GetResource("Validation.Password.IsNotEmpty"));

            SetDatabaseValidationRules<Topic>(dataProvider);
        }
    }
}
