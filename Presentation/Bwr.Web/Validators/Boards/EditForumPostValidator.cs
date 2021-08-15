using FluentValidation;
using Bwr.Services.Localization;
using Bwr.Web.Framework.Validators;
using Bwr.Web.Models.Boards;

namespace Bwr.Web.Validators.Boards
{
    public partial class EditForumPostValidator : BaseNopValidator<EditForumPostModel>
    {
        public EditForumPostValidator(ILocalizationService localizationService)
        {            
            RuleFor(x => x.Text).NotEmpty().WithMessage(localizationService.GetResource("Forum.TextCannotBeEmpty"));
        }
    }
}