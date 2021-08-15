using Bwr.Core;
using Bwr.Core.Domain.Orders;
using Bwr.Services.Customers;
using Bwr.Services.Orders;
using Bwr.Services.Security;
using Bwr.Web.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Web.Factories.Mobile
{
    public class WishlistMobFactory : IWishlistMobFactory
    {

        #region Fields

        //private readonly CaptchaSettings _captchaSettings;
        //private readonly CustomerSettings _customerSettings;
        //private readonly ICacheKeyService _cacheKeyService;
        //private readonly ICheckoutAttributeParser _checkoutAttributeParser;
        //private readonly ICheckoutAttributeService _checkoutAttributeService;
        //private readonly ICurrencyService _currencyService;
        //private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        //private readonly IDiscountService _discountService;
        //private readonly IDownloadService _downloadService;
        //private readonly IGenericAttributeService _genericAttributeService;
        //private readonly IGiftCardService _giftCardService;
        //private readonly ILocalizationService _localizationService;
        //private readonly INopFileProvider _fileProvider;
        //private readonly INotificationService _notificationService;
        //private readonly IPermissionService _permissionService;
        //private readonly IPictureService _pictureService;
        //private readonly IPriceFormatter _priceFormatter;
        //private readonly IProductAttributeParser _productAttributeParser;
        //private readonly IProductAttributeService _productAttributeService;
        //private readonly IProductService _productService;
        //private readonly IShippingService _shippingService;
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IShoppingCartService _shoppingCartService;
        //private readonly IStaticCacheManager _staticCacheManager;
        private readonly IStoreContext _storeContext;
        //private readonly ITaxService _taxService;
        //private readonly IUrlRecordService _urlRecordService;
        //private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        //private readonly IWorkflowMessageService _workflowMessageService;
        //private readonly MediaSettings _mediaSettings;
        private readonly OrderSettings _orderSettings;
        private readonly ShoppingCartSettings _shoppingCartSettings;

        #endregion

        #region Ctor

        public WishlistMobFactory(
            //CaptchaSettings captchaSettings,
            //CustomerSettings customerSettings,
            //ICacheKeyService cacheKeyService,
            //ICheckoutAttributeParser checkoutAttributeParser,
            //ICheckoutAttributeService checkoutAttributeService,
            //ICurrencyService currencyService,
            //ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            //IDiscountService discountService,
            //IDownloadService downloadService,
            //IGenericAttributeService genericAttributeService,
            //IGiftCardService giftCardService,
            //ILocalizationService localizationService,
            //INopFileProvider fileProvider,
            //INotificationService notificationService,
            //IPermissionService permissionService,
            //IPictureService pictureService,
            //IPriceFormatter priceFormatter,
            //IProductAttributeParser productAttributeParser,
            //IProductAttributeService productAttributeService,
            //IProductService productService,
            //IShippingService shippingService,
            IShoppingCartModelFactory shoppingCartModelFactory,
            IShoppingCartService shoppingCartService,
            //IStaticCacheManager staticCacheManager,
            IStoreContext storeContext,
            //ITaxService taxService,
            //IUrlRecordService urlRecordService,
            //IWebHelper webHelper,
            IWorkContext workContext,
            //IWorkflowMessageService workflowMessageService,
            //MediaSettings mediaSettings,
            OrderSettings orderSettings,
            ShoppingCartSettings shoppingCartSettings)
        {
            //_captchaSettings = captchaSettings;
            //_customerSettings = customerSettings;
            //_cacheKeyService = cacheKeyService;
            //_checkoutAttributeParser = checkoutAttributeParser;
            //_checkoutAttributeService = checkoutAttributeService;
            //_currencyService = currencyService;
            //_customerActivityService = customerActivityService;
            _customerService = customerService;
            //_discountService = discountService;
            //_downloadService = downloadService;
            //_genericAttributeService = genericAttributeService;
            //_giftCardService = giftCardService;
            //_localizationService = localizationService;
            //_fileProvider = fileProvider;
            //_notificationService = notificationService;
            //_permissionService = permissionService;
            //_pictureService = pictureService;
            //_priceFormatter = priceFormatter;
            //_productAttributeParser = productAttributeParser;
            //_productAttributeService = productAttributeService;
            //_productService = productService;
            //_shippingService = shippingService;
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _shoppingCartService = shoppingCartService;
            //_staticCacheManager = staticCacheManager;
            _storeContext = storeContext;
            //_taxService = taxService;
            //_urlRecordService = urlRecordService;
            //_webHelper = webHelper;
            _workContext = workContext;
            //_workflowMessageService = workflowMessageService;
            //_mediaSettings = mediaSettings;
            _orderSettings = orderSettings;
            _shoppingCartSettings = shoppingCartSettings;
        }

        #endregion

        public WishlistModel Wishlist(Guid? customerGuid)
        {

            var customer = customerGuid.HasValue ?
                _customerService.GetCustomerByGuid(customerGuid.Value)
                : _workContext.CurrentCustomer;
            if (customer == null)
                return null;

            var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.Wishlist, _storeContext.CurrentStore.Id);

            var model = new WishlistModel();
            model = _shoppingCartModelFactory.PrepareWishlistModel(model, cart, !customerGuid.HasValue);
            return model;
        }
    }
}
