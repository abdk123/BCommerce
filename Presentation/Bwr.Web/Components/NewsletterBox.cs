using Microsoft.AspNetCore.Mvc;
using Bwr.Core.Domain.Customers;
using Bwr.Web.Factories;
using Bwr.Web.Framework.Components;

namespace Bwr.Web.Components
{
    public class NewsletterBoxViewComponent : NopViewComponent
    {
        private readonly CustomerSettings _customerSettings;
        private readonly INewsletterModelFactory _newsletterModelFactory;

        public NewsletterBoxViewComponent(CustomerSettings customerSettings, INewsletterModelFactory newsletterModelFactory)
        {
            _customerSettings = customerSettings;
            _newsletterModelFactory = newsletterModelFactory;
        }

        public IViewComponentResult Invoke()
        {
            if (_customerSettings.HideNewsletterBlock)
                return Content("");

            var model = _newsletterModelFactory.PrepareNewsletterBoxModel();
            return View(model);
        }
    }
}
