using Microsoft.AspNetCore.Mvc;
using Bwr.Web.Factories.Mobile;
using System.Linq;
using Bwr.Core.Domain.Catalog;
using Bwr.Services.Catalog;
using Bwr.Core;
using Bwr.Core.Domain.Media;

namespace Bwr.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly ICatalogMobFactory _catalogMobFactory;
        private readonly IProductHomePageMobFactory _productHomePageFactory;
        private readonly IHomepageBestSellersMobFactory _homepageBestSellersFactory;
        private readonly IProductService _productService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly IProductModelMobFactory _productModelMobFactory;
        private readonly MediaSettings _mediaSettings;

        public HomeController(CatalogSettings catalogSettings,
            ICatalogMobFactory catalogMobFactory, 
            IProductHomePageMobFactory productHomePageFactory,
            IHomepageBestSellersMobFactory homepageBestSellersFactory,
            IProductService productService,
            IStoreContext storeContext,
            IWorkContext workContext,
            IProductModelMobFactory productModelMobFactory,
            MediaSettings mediaSettings
            )
        {
            _catalogSettings = catalogSettings;
            _catalogMobFactory = catalogMobFactory;
            _productHomePageFactory = productHomePageFactory;
            _homepageBestSellersFactory = homepageBestSellersFactory;
            _productService = productService;
            _storeContext = storeContext;
            _workContext = workContext;
            _productModelMobFactory = productModelMobFactory;
            _mediaSettings = mediaSettings;
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
        [Route("SearchTermAutoComplete")]
        public virtual IActionResult SearchTermAutoComplete(string term)
        {
            if (string.IsNullOrWhiteSpace(term) || term.Length < _catalogSettings.ProductSearchTermMinimumLength)
                return Content("");

            //products
            var productNumber = _catalogSettings.ProductSearchAutoCompleteNumberOfProducts > 0 ?
                _catalogSettings.ProductSearchAutoCompleteNumberOfProducts : 10;

            var products = _productService.SearchProducts(
                storeId: _storeContext.CurrentStore.Id,
                keywords: term,
                languageId: _workContext.WorkingLanguage.Id,
                visibleIndividuallyOnly: true,
                pageSize: productNumber);

            var showLinkToResultSearch = _catalogSettings.ShowLinkToAllResultInSearchAutoComplete && (products.TotalCount > productNumber);

            var models = _productModelMobFactory.PrepareProductOverviewModels(products, true, true, _mediaSettings.AutoCompleteSearchThumbPictureSize).ToList();
            var result = (from p in models
                          select new
                          {
                              label = p.Name,
                              Id = p.Id,
                              productpictureurl = p.DefaultPictureModel.ImageUrl
                          })
                .ToList();
            return Ok(result);
        }


    }
}
