using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories.Mobile;
using System.Linq;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICatalogMobFactory _catalogMobFactory;
        private readonly IProductHomePageMobFactory _productHomePageFactory;
        private readonly IHomepageBestSellersMobFactory _homepageBestSellersFactory;
        private readonly IHomepagePollsMobFactory _homepagePollsFactory;
        public HomeController(ICatalogMobFactory catalogMobFactory, 
            IProductHomePageMobFactory productHomePageFactory,
            IHomepageBestSellersMobFactory homepageBestSellersFactory,
            IHomepagePollsMobFactory homepagePollsFactory)
        {
            _catalogMobFactory = catalogMobFactory;
            _productHomePageFactory = productHomePageFactory;
            _homepageBestSellersFactory = homepageBestSellersFactory;
            _homepagePollsFactory = homepagePollsFactory;
        }

        [HttpGet]
        [Route("GetHomepageCategories")]
        public IActionResult GetHomepageCategories()
        {
            var model = _catalogMobFactory.PrepareHomepageCategoryModels();
            if (!model.Any())
                return BadRequest();

            return Ok(model);
        }

        [HttpGet]
        [Route("GetSimpleCategories")]
        public IActionResult GetSimpleCategories()
        {
            var model = _catalogMobFactory.PrepareCategorySimpleModels();
            if (!model.Any())
                return BadRequest();

            return Ok(model);
        }

        [HttpGet]
        [Route("GetHomePageProducts")]
        public IActionResult GetHomePageProducts(int? productPictureSize)
        {
            var model = _productHomePageFactory.GetHomePageProducts(productPictureSize);
            if (!model.Any())
                return BadRequest();

            return Ok(model);
        }

        [HttpGet]
        [Route("GetHomePageBestSellers")]
        public IActionResult GetHomePageBestSellers(int? productPictureSize)
        {
            var model = _homepageBestSellersFactory.GetHomepageBestSellers(productPictureSize);
            if (!model.Any())
                return BadRequest();

            return Ok(model);
        }

        [HttpGet]
        [Route("GetHomePagePolls")]
        public IActionResult GetHomePagePolls()
        {
            var model = _homepagePollsFactory.GetHomePagePolls();
            if (!model.Any())
                return BadRequest();

            return Ok(model);
        }
    }
}
