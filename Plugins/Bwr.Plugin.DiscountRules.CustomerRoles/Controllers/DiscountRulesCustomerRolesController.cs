using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bwr.Core.Domain.Discounts;
using Bwr.Plugin.DiscountRules.CustomerRoles.Models;
using Bwr.Services.Configuration;
using Bwr.Services.Customers;
using Bwr.Services.Discounts;
using Bwr.Services.Localization;
using Bwr.Services.Security;
using Bwr.Web.Framework;
using Bwr.Web.Framework.Controllers;
using Bwr.Web.Framework.Mvc.Filters;

namespace Bwr.Plugin.DiscountRules.CustomerRoles.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class DiscountRulesCustomerRolesController : BasePluginController
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IDiscountService _discountService;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public DiscountRulesCustomerRolesController(ICustomerService customerService,
            IDiscountService discountService,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            ISettingService settingService)
        {
            _customerService = customerService;
            _discountService = discountService;
            _localizationService = localizationService;
            _permissionService = permissionService;
            _settingService = settingService;
        }

        #endregion

        #region Methods

        public IActionResult Configure(int discountId, int? discountRequirementId)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDiscounts))
                return Content("Access denied");

            //load the discount
            var discount = _discountService.GetDiscountById(discountId);
            if (discount == null)
                throw new ArgumentException("Discount could not be loaded");

            //check whether the discount requirement exists
            if (discountRequirementId.HasValue && _discountService.GetDiscountRequirementById(discountRequirementId.Value) is null)
                return Content("Failed to load requirement.");

            //try to get previously saved restricted customer role identifier
            var restrictedRoleId = _settingService.GetSettingByKey<int>(string.Format(DiscountRequirementDefaults.SettingsKey, discountRequirementId ?? 0));

            var model = new RequirementModel
            {
                RequirementId = discountRequirementId ?? 0,
                DiscountId = discountId,
                CustomerRoleId = restrictedRoleId
            };

            //set available customer roles
            model.AvailableCustomerRoles = _customerService.GetAllCustomerRoles(true).Select(role => new SelectListItem
            {
                Text = role.Name,
                Value = role.Id.ToString(),
                Selected = role.Id == restrictedRoleId
            }).ToList();
            model.AvailableCustomerRoles.Insert(0, new SelectListItem
            {
                Text = _localizationService.GetResource("Plugins.DiscountRules.CustomerRoles.Fields.CustomerRole.Select"),
                Value = "0"
            });

            //set the HTML field prefix
            ViewData.TemplateInfo.HtmlFieldPrefix = string.Format(DiscountRequirementDefaults.HtmlFieldPrefix, discountRequirementId ?? 0);

            return View("~/Plugins/DiscountRules.CustomerRoles/Views/Configure.cshtml", model);
        }

        [HttpPost]        
        public IActionResult Configure(RequirementModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageDiscounts))
                return Content("Access denied");

            if (ModelState.IsValid)
            {
                //load the discount
                var discount = _discountService.GetDiscountById(model.DiscountId);
                if (discount == null)
                    return NotFound(new { Errors = new[] { "Discount could not be loaded" } });

                //get the discount requirement
                var discountRequirement = _discountService.GetDiscountRequirementById(model.RequirementId);

                //the discount requirement does not exist, so create a new one
                if (discountRequirement == null)
                {
                    discountRequirement = new DiscountRequirement
                    {
                        DiscountId = discount.Id,
                        DiscountRequirementRuleSystemName = DiscountRequirementDefaults.SystemName
                    };

                    _discountService.InsertDiscountRequirement(discountRequirement);
                }

                //save restricted customer role identifier
                _settingService.SetSetting(string.Format(DiscountRequirementDefaults.SettingsKey, discountRequirement.Id), model.CustomerRoleId);

                return Ok(new { NewRequirementId = discountRequirement.Id });
            }

            return BadRequest(new { Errors = GetErrorsFromModelState(ModelState) });
        }

        #endregion

        #region Utilities

        private IEnumerable<string> GetErrorsFromModelState(ModelStateDictionary modelState)
        {
            return ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        }

        #endregion
    }
}