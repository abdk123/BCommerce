﻿using System.Collections.Generic;
using Bwr.Web.Framework.Models;
using Bwr.Web.Framework.Mvc.ModelBinding;

namespace Bwr.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents an address attribute value model
    /// </summary>
    public partial class AddressAttributeValueModel : BaseNopEntityModel, ILocalizedModel<AddressAttributeValueLocalizedModel>
    {
        #region Ctor

        public AddressAttributeValueModel()
        {
            Locales = new List<AddressAttributeValueLocalizedModel>();
        }

        #endregion

        #region Properties

        public int AddressAttributeId { get; set; }

        [NopResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.Name")]
        public string Name { get; set; }

        [NopResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [NopResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<AddressAttributeValueLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class AddressAttributeValueLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Address.AddressAttributes.Values.Fields.Name")]
        public string Name { get; set; }
    }
}