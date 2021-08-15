using Microsoft.AspNetCore.Mvc;
using Bwr.Core.Domain.Orders;
using Bwr.Core.Http.Extensions;
using Bwr.Plugin.Payments.PayPalSmartPaymentButtons.Models;
using Bwr.Plugin.Payments.PayPalSmartPaymentButtons.Services;
using Bwr.Services.Localization;
using Bwr.Services.Messages;
using Bwr.Services.Payments;
using Bwr.Web.Framework.Components;

namespace Bwr.Plugin.Payments.PayPalSmartPaymentButtons.Components
{
    /// <summary>
    /// Represents the view component to display payment info in public store
    /// </summary>
    [ViewComponent(Name = Defaults.PAYMENT_INFO_VIEW_COMPONENT_NAME)]
    public class PaymentInfoViewComponent : NopViewComponent
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPaymentService _paymentService;
        private readonly OrderSettings _orderSettings;
        private readonly PayPalSmartPaymentButtonsSettings _settings;
        private readonly ServiceManager _serviceManager;

        #endregion

        #region Ctor

        public PaymentInfoViewComponent(ILocalizationService localizationService,
            INotificationService notificationService,
            IPaymentService paymentService,
            OrderSettings orderSettings,
            PayPalSmartPaymentButtonsSettings settings,
            ServiceManager serviceManager)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _paymentService = paymentService;
            _orderSettings = orderSettings;
            _settings = settings;
            _serviceManager = serviceManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <param name="additionalData">Additional data</param>
        /// <returns>View component result</returns>
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var model = new PaymentInfoModel();

            //prepare order GUID
            var paymentRequest = new ProcessPaymentRequest();
            _paymentService.GenerateOrderGuid(paymentRequest);

            //try to create an order
            var (order, errorMessage) = _serviceManager.CreateOrder(_settings, paymentRequest.OrderGuid);
            if (order != null)
            {
                model.OrderId = order.Id;

                //save order details for future using
                paymentRequest.CustomValues.Add(_localizationService.GetResource("Plugins.Payments.PayPalSmartPaymentButtons.OrderId"), order.Id);
            }
            else if (!string.IsNullOrEmpty(errorMessage))
            {
                model.Errors = errorMessage;
                if (_orderSettings.OnePageCheckoutEnabled)
                    ModelState.AddModelError(string.Empty, errorMessage);
                else
                    _notificationService.ErrorNotification(errorMessage);
            }

            HttpContext.Session.Set(Defaults.PaymentRequestSessionKey, paymentRequest);

            return View("~/Plugins/Payments.PayPalSmartPaymentButtons/Views/PaymentInfo.cshtml", model);
        }

        #endregion
    }
}