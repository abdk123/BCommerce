using FluentValidation;
using Bwr.Services.Localization;
using Bwr.Web.Areas.Admin.Models.Plugins;
using Bwr.Web.Framework.Validators;

namespace Bwr.Web.Areas.Admin.Validators.Plugins
{
    public partial class PluginValidator : BaseNopValidator<PluginModel>
    {
        public PluginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FriendlyName).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Plugins.Fields.FriendlyName.Required"));
        }
    }
}