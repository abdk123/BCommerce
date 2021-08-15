using Bwr.Web.Framework.Models;

namespace Bwr.Plugin.Misc.SendinBlue.Models
{
    /// <summary>
    /// Represents message template model
    /// </summary>
    public class SendinBlueMessageTemplateModel : BaseNopEntityModel
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public string ListOfStores { get; set; }

        public bool UseSendinBlueTemplate { get; set; }

        public string EditLink { get; set; }
    }
}