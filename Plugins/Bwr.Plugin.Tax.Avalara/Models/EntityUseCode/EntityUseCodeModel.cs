using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Plugin.Tax.Avalara.Models.EntityUseCode
{
    /// <summary>
    /// Represents an entity use code model
    /// </summary>
    public class EntityUseCodeModel : BaseNopEntityModel
    {
        #region Ctor

        public EntityUseCodeModel()
        {
            EntityUseCodes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public string PrecedingElementId { get; set; }

        [NopResourceDisplayName("Plugins.Tax.Avalara.Fields.EntityUseCode")]
        public string AvalaraEntityUseCode { get; set; }
        public List<SelectListItem> EntityUseCodes { get; set; }

        #endregion
    }
}