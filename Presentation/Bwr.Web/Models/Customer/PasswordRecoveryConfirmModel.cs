﻿using System.ComponentModel.DataAnnotations;
using Bwr.Web.Framework.Mvc.ModelBinding;
using Bwr.Web.Framework.Models;

namespace Bwr.Web.Models.Customer
{
    public partial class PasswordRecoveryConfirmModel : BaseNopModel
    {
        [DataType(DataType.Password)]
        [NoTrim]
        [NopResourceDisplayName("Account.PasswordRecovery.NewPassword")]
        public string NewPassword { get; set; }
        
        [NoTrim]
        [DataType(DataType.Password)]
        [NopResourceDisplayName("Account.PasswordRecovery.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public bool DisablePasswordChanging { get; set; }
        public string Result { get; set; }
    }
}