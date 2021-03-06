using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bwr.Core.Domain.Orders;
using Bwr.Core.Domain.Catalog;
using Bwr.Services.Catalog;
using Bwr.Services.Orders;
using Bwr.Services.Customers;
using Bwr.Core;
using Bwr.Web.Models.ShoppingCart;
using Bwr.Web.Factories;
using Bwr.Web.Models.Mobile.ShoppingCart;
using Bwr.Core.Domain.Customers;
using Bwr.Services.Common;
using Bwr.Services.Discounts;
using Bwr.Services.Localization;
using Microsoft.Extensions.Primitives;
using Bwr.Web.Factories.Mobile;

namespace Bwr.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        #region Fields 

        private readonly IProductService _productService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IGiftCardService _giftCardService;
        private readonly ICustomerService _customerService;
        private readonly IStoreContext _storeContext;
        private readonly IShoppingCartModelFactory _shoppingCartModelFactory;
        private readonly IProductModelMobFactory _productModelFactory;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IDiscountService _discountService;
        private readonly ILocalizationService _localizationService;
        #endregion
        #region ctor
        public ShoppingCartController(IProductService productService,
            IProductAttributeParser productAttributeParser,
            IProductAttributeService productAttributeService,
            IShoppingCartService shoppingCartService,
            ICustomerService customerService,
            IProductModelMobFactory productModelFactory,
            IStoreContext storeContext,
            IGiftCardService giftCardService,
            IShoppingCartModelFactory shoppingCartModelFactory,
            IGenericAttributeService genericAttributeService,
            IDiscountService discountService,
            ILocalizationService localizationService)
        {
            _productAttributeParser = productAttributeParser;
            _productAttributeService = productAttributeService;
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _customerService = customerService;
            _storeContext = storeContext;
            _giftCardService = giftCardService;
            _productModelFactory = productModelFactory;
            _shoppingCartModelFactory = shoppingCartModelFactory;
            _genericAttributeService = genericAttributeService;
            _discountService = discountService;
            _localizationService = localizationService;
        }

        #endregion
        [HttpGet]
        [Route("Cart")]
        public virtual IActionResult Cart()
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });
            var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);
            var model = new ShoppingCartModel();
            model = _shoppingCartModelFactory.PrepareShoppingCartModel(model, cart);
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = new { Items = model.Items, Total = PrepareTotal(customer) }
            });
        }

        [HttpPost]
        [Route("CheckProductIfHasAttributes")]
        public IActionResult CheckProductIfHasAttributes(int ProductId)
        {

            var product = _productService.GetProductById(ProductId);
            if (product == null)
                //no product found
                return Ok(new
                {
                    Success = false,
                    Msg = "No product found with the specified ID"
                });
            var productAttributes = _productAttributeService.GetProductAttributeMappingsByProductId(product.Id);
            if(productAttributes.Any(x=> x.IsRequired))
                return Ok(new
                {
                    Success = false,
                    Msg = "product has some required attributes, customer should see them."
                });
            return Ok(new
            {
                Success = true,
                Msg = "no required attributes"
            });
        }
        [HttpPost]
        [Route("AddProductToCart")]
        public IActionResult AddProductToCart(UpdatedItemsInCart newItem)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });
            var cartType = (ShoppingCartType)1;

            var product = _productService.GetProductById(newItem.ProductId);
            if (product == null)
                //no product found
                return Ok(new
                {
                    Success = false,
                    Msg = "No product found with the specified ID"
                });

            //we can add only simple products
            if (product.ProductType != ProductType.SimpleProduct)
                return Ok(new
                {
                    Success = false,
                    Msg = "Product type is not simple"
                });

            //products with "minimum order quantity" more than a specified qty
            if (product.OrderMinimumQuantity > newItem.Quantity)
                //we cannot add to the cart such products from category pages
                //it can confuse customers. That's why we redirect customers to the product details page
                return Ok(new
                {
                    Success = false,
                    Msg = "minimum order quantity is " + product.OrderMinimumQuantity
                });

            var allowedQuantities = _productService.ParseAllowedQuantities(product);
            //if (allowedQuantities.Length > 0)
            //{
            //    //cannot be added to the cart (requires a customer to select a quantity from dropdownlist)
            //    return Json(new
            //    {
            //        redirect = Url.RouteUrl("Product", new { SeName = _urlRecordService.GetSeName(product) })
            //    });
            //allow a product to be added to the cart when all attributes are with "read-only checkboxes" type
            var productAttributes = _productAttributeService.GetProductAttributeMappingsByProductId(product.Id);
            if (productAttributes.Any(x => x.IsRequired))
            {
                if (newItem.ProductAttributes.Any())
                {
                    foreach (var att in productAttributes)
                        if (att.IsRequired)
                        {
                            var attribute = newItem.ProductAttributes.FirstOrDefault(x => x.AttributeId == att.Id);
                            if (attribute == null)
                                return Ok(new
                                {
                                    Success = false,
                                    Msg = "product attribute with Id " + att.Id + " is required"
                                });
                        }
                }
                else
                    return Ok(new
                    {
                        Success = false,
                        Msg = "product has some attributes, customer should see them."
                    });
            }

            var addToCartWarnings = new List<string>();
            var fields = new Dictionary<string, StringValues>();
            foreach (var item in newItem.ProductAttributes)
            {
                var controlId = $"{NopCatalogDefaults.ProductAttributePrefix}{item.AttributeId}";
                fields.Add(controlId, item.Values);
            }
            FormCollection form = new FormCollection(fields);
            //product and gift card attributes
            var attributes = _productAttributeParser.ParseProductAttributes(product, form, addToCartWarnings);
            //get standard warnings without attribute validations
            //first, try to find existing shopping cart item
            var cart = _shoppingCartService.GetShoppingCart(customer, cartType, _storeContext.CurrentStore.Id);
            var shoppingCartItem = _shoppingCartService.FindShoppingCartItemInTheCart(cart, cartType, product);
            //if we already have the same product in the cart, then use the total quantity to validate
            var quantityToValidate = shoppingCartItem != null ? shoppingCartItem.Quantity + newItem.Quantity : newItem.Quantity;
            addToCartWarnings = _shoppingCartService
                .GetShoppingCartItemWarnings(customer, cartType,
                product, _storeContext.CurrentStore.Id, attributes,
                decimal.Zero, null, null, quantityToValidate, false, shoppingCartItem?.Id ?? 0, true, false, false, false).ToList();
            if (addToCartWarnings.Any())
                //cannot be added to the cart
                //let's display standard warnings
                return Ok(new
                {
                    Success = false,
                    Msg = addToCartWarnings.ToArray()
                });

            //now let's try adding product to the cart (now including product attribute validation, etc)
            addToCartWarnings = _shoppingCartService.AddToCart(customer: customer,
                product: product,
                shoppingCartType: cartType,
                storeId: _storeContext.CurrentStore.Id,
                attributesXml: attributes,
                quantity: newItem.Quantity).ToList();
            if (addToCartWarnings.Any())
                //cannot be added to the cart
                //but we do not display attribute and gift card warnings here. let's do it on the product details page
                return Ok(new
                {
                    Success = false,
                    Msg = addToCartWarnings.ToArray()
                });
            return Ok(new
            {
                Success = true,
                Msg = "Product has added to cart",
            });
        }
        [HttpPost]
        [Route("UpdateCart")]
        public IActionResult UpdateCart(UpdatedCartMobModel updatedCartModel)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });

            var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);


            var productIds = updatedCartModel.Items.Select(x => x.ProductId).ToList();
            var products = _productService.GetProductsByIds(cart.Select(item => item.ProductId).Distinct().ToArray())
                .ToDictionary(item => item.Id, item => item);
            //get identifiers of items to remove
            var itemIdsToRemove = products.Where(x => productIds.Any(y => y != x.Key)).Select(x => x.Key).ToList();
            //get identifiers of items to add
            var itemIdsToAdd = cart.Any() ? productIds.Where(x => products.Any(y => y.Key != x)).ToList() : productIds;

            var _addToCartWarnings = new List<string>();
            foreach (var updated in updatedCartModel.Items)
            {

                var _product = _productService.GetProductById(updated.ProductId);
                var fields = new Dictionary<string, StringValues>();
                foreach (var item in updated.ProductAttributes)
                {
                    var controlId = $"{NopCatalogDefaults.ProductAttributePrefix}{item.AttributeId}";
                    fields.Add(controlId, item.Values);
                }
                FormCollection form = new FormCollection(fields);
                //product and gift card attributes
                var attributes = _productAttributeParser.ParseProductAttributes(_product, form, _addToCartWarnings);
                updated.XmlAttribute = attributes;
            }
            //get order items with changed quantity
            var itemsWithNewQuantity = cart.Select(item => new
            {
                //try to get a new quantity for the item, set 0 for items to remove
                NewQuantity = itemIdsToRemove.Contains(item.ProductId) ? 0 :
                updatedCartModel.Items.Any(x => x.ProductId == item.ProductId) &&
                updatedCartModel.Items.Where(x=> x.ProductId == item.ProductId).FirstOrDefault().Quantity != 0 ?
                updatedCartModel.Items.Where(x => x.ProductId == item.ProductId).FirstOrDefault().Quantity : item.Quantity,
                Item = item,
                Product = products.ContainsKey(item.ProductId) ? products[item.ProductId] : null
            }).Where(item => item.NewQuantity != item.Item.Quantity);

            //order cart items
            //first should be items with a reduced quantity and that require other products; or items with an increased quantity and are required for other products
            var orderedCart = itemsWithNewQuantity
                .OrderByDescending(cartItem =>
                    (cartItem.NewQuantity < cartItem.Item.Quantity &&
                     (cartItem.Product?.RequireOtherProducts ?? false)) ||
                    (cartItem.NewQuantity > cartItem.Item.Quantity && cartItem.Product != null && _shoppingCartService
                         .GetProductsRequiringProduct(cart, cartItem.Product).Any()))
                .ToList();

            //try to update cart items with new quantities and get warnings
            var warnings = orderedCart.Select(cartItem => new
            {
                ItemId = cartItem.Item.Id,
                Warnings = _shoppingCartService.UpdateShoppingCartItem(customer,
                    cartItem.Item.Id, cartItem.Item.AttributesXml, cartItem.Item.CustomerEnteredPrice,
                    cartItem.Item.RentalStartDateUtc, cartItem.Item.RentalEndDateUtc, cartItem.NewQuantity, true)
            }).ToList();

            //updated cart
            cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);
            var _products = _productService.GetProductsByIds(itemIdsToAdd.ToArray()).ToList();
            var productsFromModel = updatedCartModel.Items.Where(x => itemIdsToAdd.Any(y => y == x.ProductId)).ToList();
            foreach (var p in productsFromModel)
            {
                var item = _productService.GetProductById(p.ProductId);
                warnings.Add(new
                {
                    ItemId = item.Id,
                    Warnings = _shoppingCartService.AddToCart(customer: customer,
                              product: item,
                              shoppingCartType: ShoppingCartType.ShoppingCart,
                              attributesXml: p.XmlAttribute,
                              storeId: _storeContext.CurrentStore.Id,
                              quantity: p.Quantity)
                });
            }
            //updated cart
            cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);
            foreach (var item in _products)
                if(warnings.Any(x => x.ItemId == item.Id))
                {
                    var warning = warnings.FirstOrDefault(x => x.ItemId == item.Id);
                    warnings.Remove(warning);
                    warnings.Add(new
                    {
                        ItemId = cart.FirstOrDefault(x => x.ProductId == item.Id).Id,
                        Warnings= warning.Warnings
                    });
                }
            //parse and save checkout attributes
            //ParseAndSaveCheckoutAttributes(cart, form);

            //prepare model
            var model = new ShoppingCartModel();
            model = _shoppingCartModelFactory.PrepareShoppingCartModel(model, cart);

            //update current warnings
            foreach (var warningItem in warnings.Where(warningItem => warningItem.Warnings.Any()))
            {
                //find shopping cart item model to display appropriate warnings
                var itemModel = model.Items.FirstOrDefault(item => item.Id == warningItem.ItemId);
                if (itemModel != null)
                    itemModel.Warnings = warningItem.Warnings.Concat(itemModel.Warnings).Distinct().ToList();
            }
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = new { Items = model.Items, Warnings = model.Warnings, Total = PrepareTotal(customer) }
            });
        }
        [HttpPost]
        [Route("ApplyGiftCard")]
        public virtual IActionResult ApplyGiftCard(string giftcardcouponcode, IFormCollection form)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });
            //trim
            if (giftcardcouponcode != null)
                giftcardcouponcode = giftcardcouponcode.Trim();

            //cart
            var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);


            var model = new ShoppingCartModel();
            if (!_shoppingCartService.ShoppingCartIsRecurring(cart))
            {
                if (!string.IsNullOrWhiteSpace(giftcardcouponcode))
                {
                    var giftCard = _giftCardService.GetAllGiftCards(giftCardCouponCode: giftcardcouponcode).FirstOrDefault();
                    var isGiftCardValid = giftCard != null && _giftCardService.IsGiftCardValid(giftCard);
                    if (isGiftCardValid)
                    {
                        _customerService.ApplyGiftCardCouponCode(customer, giftcardcouponcode);
                        model.GiftCardBox.Message = _localizationService.GetResource("ShoppingCart.GiftCardCouponCode.Applied");
                        model.GiftCardBox.IsApplied = true;
                    }
                    else
                    {
                        model.GiftCardBox.Message = _localizationService.GetResource("ShoppingCart.GiftCardCouponCode.WrongGiftCard");
                        model.GiftCardBox.IsApplied = false;
                    }
                }
                else
                {
                    model.GiftCardBox.Message = _localizationService.GetResource("ShoppingCart.GiftCardCouponCode.WrongGiftCard");
                    model.GiftCardBox.IsApplied = false;
                }
            }
            else
            {
                model.GiftCardBox.Message = _localizationService.GetResource("ShoppingCart.GiftCardCouponCode.DontWorkWithAutoshipProducts");
                model.GiftCardBox.IsApplied = false;
            }

            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = new { Data = model.GiftCardBox }
            });
        }

        [HttpPost]
        [Route("ApplyDiscountCoupon")]
        public IActionResult ApplyDiscountCoupon(string discountcouponcode, IFormCollection form)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });
            //trim
            if (discountcouponcode != null)
                discountcouponcode = discountcouponcode.Trim();

            //cart
            var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);

            //parse and save checkout attributes
            //ParseAndSaveCheckoutAttributes(cart, form);
            var attributesXml = string.Empty;
            _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.CheckoutAttributes, attributesXml, _storeContext.CurrentStore.Id);
            var model = new ShoppingCartModel();
            if (!string.IsNullOrWhiteSpace(discountcouponcode))
            {
                //we find even hidden records here. this way we can display a user-friendly message if it's expired
                var discounts = _discountService.GetAllDiscounts(couponCode: discountcouponcode, showHidden: true)
                    .Where(d => d.RequiresCouponCode)
                    .ToList();
                if (discounts.Any())
                {
                    var userErrors = new List<string>();
                    var anyValidDiscount = discounts.Any(discount =>
                    {
                        var validationResult = _discountService.ValidateDiscount(discount, customer, new[] { discountcouponcode });
                        userErrors.AddRange(validationResult.Errors);

                        return validationResult.IsValid;
                    });

                    if (anyValidDiscount)
                    {
                        //valid
                        _customerService.ApplyDiscountCouponCode(customer, discountcouponcode);
                        model.DiscountBox.Messages.Add(_localizationService.GetResource("ShoppingCart.DiscountCouponCode.Applied"));
                        model.DiscountBox.IsApplied = true;
                    }
                    else
                    {
                        if (userErrors.Any())
                            //some user errors
                            model.DiscountBox.Messages = userErrors;
                        else
                            //general error text
                            model.DiscountBox.Messages.Add(_localizationService.GetResource("ShoppingCart.DiscountCouponCode.WrongDiscount"));
                    }
                }
                else
                    //discount cannot be found
                    model.DiscountBox.Messages.Add(_localizationService.GetResource("ShoppingCart.DiscountCouponCode.CannotBeFound"));
            }
            else
                //empty coupon code
                model.DiscountBox.Messages.Add(_localizationService.GetResource("ShoppingCart.DiscountCouponCode.Empty"));

            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = new { Discounts = model.DiscountBox }
            });
        }
        public OrderTotalMobModel PrepareTotal(Customer customer)
        {
            var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);

            var model = _shoppingCartModelFactory.PrepareOrderTotalsModel(cart, true);
            return new OrderTotalMobModel()
            {
                OrderTotal = model.OrderTotal,
                OrderTotalDiscount = model.OrderTotalDiscount,
                SubTotal = model.SubTotal,
                GiftCards = model.GiftCards,
                SubTotalDiscount = model.SubTotalDiscount,
                Shipping = model.Shipping
            };
        }
        [HttpGet]
        [Route("Total")]
        public IActionResult GetTotal()
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });

            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = new { Total = PrepareTotal(customer) }
            });
        }
    }
}
