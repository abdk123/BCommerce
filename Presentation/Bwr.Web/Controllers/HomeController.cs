using Microsoft.AspNetCore.Mvc;

namespace Bwr.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}