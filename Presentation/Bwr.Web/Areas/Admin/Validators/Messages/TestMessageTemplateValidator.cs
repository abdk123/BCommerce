using FluentValidation;
using Bwr.Services.Localization;
using Bwr.Web.Areas.Admin.Models.Messages;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Messages
{
    public partial class TestMessageTemplateValidator : BaseNopValidator<TestMessageTemplateModel>
    {
        public TestMessageTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SendTo).NotEmpty();
            RuleFor(x => x.SendTo).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
        }
    }
}