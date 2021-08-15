﻿using Bwr.Core.Caching;

namespace Bwr.Web.Infrastructure.Cache
{
    public static partial class NopModelCacheDefaults
    {
        /// <summary>
        /// Key for ManufacturerNavigationModel caching
        /// </summary>
        /// <remarks>
        /// {0} : current manufacturer id
        /// {1} : language id
        /// {2} : roles of the current user
        /// {3} : current store ID
        /// </remarks>
        public static CacheKey ManufacturerNavigationModelKey => new CacheKey("Bwr.pres.manufacturer.navigation-{0}-{1}-{2}-{3}", ManufacturerNavigationPrefixCacheKey);
        public static string ManufacturerNavigationPrefixCacheKey => "Bwr.pres.manufacturer.navigation";

        /// <summary>
        /// Key for VendorNavigationModel caching
        /// </summary>
        public static CacheKey VendorNavigationModelKey => new CacheKey("Bwr.pres.vendor.navigation");

        /// <summary>
        /// Key for caching of a value indicating whether a manufacturer has featured products
        /// </summary>
        /// <remarks>
        /// {0} : manufacturer id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey ManufacturerHasFeaturedProductsKey => new CacheKey("Bwr.pres.manufacturer.hasfeaturedproducts-{0}-{1}-{2}", ManufacturerHasFeaturedProductsPrefixCacheKeyById);
        public static string ManufacturerHasFeaturedProductsPrefixCacheKeyById => "Bwr.pres.manufacturer.hasfeaturedproducts-{0}-";

        /// <summary>
        /// Key for list of CategorySimpleModel caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey CategoryAllModelKey => new CacheKey("Bwr.pres.category.all-{0}-{1}-{2}", CategoryAllPrefixCacheKey);
        public static string CategoryAllPrefixCacheKey => "Bwr.pres.category.all";

        /// <summary>
        /// Key for caching of a value indicating whether a category has featured products
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey CategoryHasFeaturedProductsKey => new CacheKey("Bwr.pres.category.hasfeaturedproducts-{0}-{1}-{2}", CategoryHasFeaturedProductsPrefixCacheKeyById);
        public static string CategoryHasFeaturedProductsPrefixCacheKeyById => "Bwr.pres.category.hasfeaturedproducts-{0}-";
        
        /// <summary>
        /// Key for caching of categories displayed on home page
        /// </summary>
        /// <remarks>
        /// {0} : picture size
        /// {1} : language ID
        /// {2} : is connection SSL secured (included in a category picture URL)
        /// </remarks>
        public static CacheKey CategoryHomepageKey => new CacheKey("Bwr.pres.category.homepage-{0}-{1}-{2}", CategoryHomepagePrefixCacheKey);
        public static string CategoryHomepagePrefixCacheKey => "Bwr.pres.category.homepage";

        /// <summary>
        /// Key for Xml document of CategorySimpleModels caching
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey CategoryXmlAllModelKey => new CacheKey("Bwr.pres.categoryXml.all-{0}-{1}-{2}", CategoryXmlAllPrefixCacheKey);
        public static string CategoryXmlAllPrefixCacheKey => "Bwr.pres.categoryXml.all";

        /// <summary>
        /// Key for SpecificationAttributeOptionFilter caching
        /// </summary>
        /// <remarks>
        /// {0} : list of specification attribute option IDs
        /// {1} : language id
        /// </remarks>
        public static CacheKey SpecsFilterModelKey => new CacheKey("Bwr.pres.filter.specs-{0}-{1}", SpecsFilterPrefixCacheKey);
        public static string SpecsFilterPrefixCacheKey => "Bwr.pres.filter.specs";

        /// <summary>
        /// Key for bestsellers identifiers displayed on the home page
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// </remarks>
        public static CacheKey HomepageBestsellersIdsKey => new CacheKey("Bwr.pres.bestsellers.homepage-{0}", HomepageBestsellersIdsPrefixCacheKey);
        public static string HomepageBestsellersIdsPrefixCacheKey => "Bwr.pres.bestsellers.homepage";

        /// <summary>
        /// Key for "also purchased" product identifiers displayed on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : current product id
        /// {1} : current store ID
        /// </remarks>
        public static CacheKey ProductsAlsoPurchasedIdsKey => new CacheKey("Bwr.pres.alsopuchased-{0}-{1}", ProductsAlsoPurchasedIdsPrefixCacheKey);
        public static string ProductsAlsoPurchasedIdsPrefixCacheKey => "Bwr.pres.alsopuchased";

        /// <summary>
        /// Key for default product picture caching (all pictures)
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : picture size
        /// {2} : isAssociatedProduct?
        /// {3} : language ID ("alt" and "title" can depend on localized product name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static CacheKey ProductDefaultPictureModelKey => new CacheKey("Bwr.pres.product.detailspictures-{0}-{1}-{2}-{3}-{4}-{5}", ProductDefaultPicturePrefixCacheKey, ProductDefaultPicturePrefixCacheKeyById);
        public static string ProductDefaultPicturePrefixCacheKey => "Bwr.pres.product.detailspictures";
        public static string ProductDefaultPicturePrefixCacheKeyById => "Bwr.pres.product.detailspictures-{0}-";

        /// <summary>
        /// Key for product picture caching on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized product name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static CacheKey ProductDetailsPicturesModelKey => new CacheKey("Bwr.pres.product.picture-{0}-{1}-{2}-{3}-{4}-{5}", ProductDetailsPicturesPrefixCacheKey, ProductDetailsPicturesPrefixCacheKeyById);
        public static string ProductDetailsPicturesPrefixCacheKey => "Bwr.pres.product.picture";
        public static string ProductDetailsPicturesPrefixCacheKeyById => "Bwr.pres.product.picture-{0}-";

        /// <summary>
        /// Key for product reviews caching
        /// </summary>
        /// <remarks>
        /// {0} : product id
        /// {1} : current store ID
        /// </remarks>
        public static CacheKey ProductReviewsModelKey => new CacheKey("Bwr.pres.product.reviews-{0}-{1}", ProductReviewsPrefixCacheKey, ProductReviewsPrefixCacheKeyById);
        public static string ProductReviewsPrefixCacheKey => "Bwr.pres.product.reviews";
        public static string ProductReviewsPrefixCacheKeyById => "Bwr.pres.product.reviews-{0}-";

        /// <summary>
        /// Key for product attribute picture caching on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : picture id
        /// {1} : is connection SSL secured?
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey ProductAttributePictureModelKey => new CacheKey("Bwr.pres.productattribute.picture-{0}-{1}-{2}", ProductAttributePicturePrefixCacheKey);
        public static string ProductAttributePicturePrefixCacheKey => "Bwr.pres.productattribute.picture";

        /// <summary>
        /// Key for product attribute picture caching on the product details page
        /// </summary>
        /// <remarks>
        /// {0} : picture id
        /// {1} : is connection SSL secured?
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey ProductAttributeImageSquarePictureModelKey => new CacheKey("Bwr.pres.productattribute.imagesquare.picture-{0}-{1}-{2}", ProductAttributeImageSquarePicturePrefixCacheKey);
        public static string ProductAttributeImageSquarePicturePrefixCacheKey => "Bwr.pres.productattribute.imagesquare.picture";

        /// <summary>
        /// Key for category picture caching
        /// </summary>
        /// <remarks>
        /// {0} : category id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized category name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static CacheKey CategoryPictureModelKey => new CacheKey("Bwr.pres.category.picture-{0}-{1}-{2}-{3}-{4}-{5}", CategoryPicturePrefixCacheKey, CategoryPicturePrefixCacheKeyById);
        public static string CategoryPicturePrefixCacheKey => "Bwr.pres.category.picture";
        public static string CategoryPicturePrefixCacheKeyById => "Bwr.pres.category.picture-{0}-";

        /// <summary>
        /// Key for manufacturer picture caching
        /// </summary>
        /// <remarks>
        /// {0} : manufacturer id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized manufacturer name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static CacheKey ManufacturerPictureModelKey => new CacheKey("Bwr.pres.manufacturer.picture-{0}-{1}-{2}-{3}-{4}-{5}", ManufacturerPicturePrefixCacheKey, ManufacturerPicturePrefixCacheKeyById);
        public static string ManufacturerPicturePrefixCacheKey => "Bwr.pres.manufacturer.picture";
        public static string ManufacturerPicturePrefixCacheKeyById => "Bwr.pres.manufacturer.picture-{0}-";

        /// <summary>
        /// Key for vendor picture caching
        /// </summary>
        /// <remarks>
        /// {0} : vendor id
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized category name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static CacheKey VendorPictureModelKey => new CacheKey("Bwr.pres.vendor.picture-{0}-{1}-{2}-{3}-{4}-{5}", VendorPicturePrefixCacheKey, VendorPicturePrefixCacheKeyById);
        public static string VendorPicturePrefixCacheKey => "Bwr.pres.vendor.picture";
        public static string VendorPicturePrefixCacheKeyById => "Bwr.pres.vendor.picture-{0}-";

        /// <summary>
        /// Key for cart picture caching
        /// </summary>
        /// <remarks>
        /// {0} : shopping cart item id
        /// P.S. we could cache by product ID. it could increase performance.
        /// but it won't work for product attributes with custom images
        /// {1} : picture size
        /// {2} : value indicating whether a default picture is displayed in case if no real picture exists
        /// {3} : language ID ("alt" and "title" can depend on localized product name)
        /// {4} : is connection SSL secured?
        /// {5} : current store ID
        /// </remarks>
        public static CacheKey CartPictureModelKey => new CacheKey("Bwr.pres.cart.picture-{0}-{1}-{2}-{3}-{4}-{5}", CartPicturePrefixCacheKey);
        public static string CartPicturePrefixCacheKey => "Bwr.pres.cart.picture";

        /// <summary>
        /// Key for home page polls
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static CacheKey HomepagePollsModelKey => new CacheKey("Bwr.pres.poll.homepage-{0}-{1}", PollsPrefixCacheKey);
        /// <summary>
        /// Key for polls by system name
        /// </summary>
        /// <remarks>
        /// {0} : poll system name
        /// {1} : language ID
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey PollBySystemNameModelKey => new CacheKey("Bwr.pres.poll.systemname-{0}-{1}-{2}", PollsPrefixCacheKey);
        public static string PollsPrefixCacheKey => "Bwr.pres.poll";

        /// <summary>
        /// Key for blog archive (years, months) block model
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static CacheKey BlogMonthsModelKey => new CacheKey("Bwr.pres.blog.months-{0}-{1}", BlogPrefixCacheKey);
        public static string BlogPrefixCacheKey => "Bwr.pres.blog";
        
        /// <summary>
        /// Key for home page news
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : current store ID
        /// </remarks>
        public static CacheKey HomepageNewsModelKey => new CacheKey("Bwr.pres.news.homepage-{0}-{1}", NewsPrefixCacheKey);
        public static string NewsPrefixCacheKey => "Bwr.pres.news";

        /// <summary>
        /// Key for logo
        /// </summary>
        /// <remarks>
        /// {0} : current store ID
        /// {1} : current theme
        /// {2} : is connection SSL secured (included in a picture URL)
        /// </remarks>
        public static CacheKey StoreLogoPath => new CacheKey("Bwr.pres.logo-{0}-{1}-{2}", StoreLogoPathPrefixCacheKey);
        public static string StoreLogoPathPrefixCacheKey => "Bwr.pres.logo";

        /// <summary>
        /// Key for sitemap on the sitemap page
        /// </summary>
        /// <remarks>
        /// {0} : language id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static CacheKey SitemapPageModelKey => new CacheKey("Bwr.pres.sitemap.page-{0}-{1}-{2}", SitemapPrefixCacheKey);
        /// <summary>
        /// Key for sitemap on the sitemap SEO page
        /// </summary>
        /// <remarks>
        /// {0} : sitemap identifier
        /// {1} : language id
        /// {2} : roles of the current user
        /// {3} : current store ID
        /// </remarks>
        public static CacheKey SitemapSeoModelKey => new CacheKey("Bwr.pres.sitemap.seo-{0}-{1}-{2}-{3}", SitemapPrefixCacheKey);
        public static string SitemapPrefixCacheKey => "Bwr.pres.sitemap";

        /// <summary>
        /// Key for widget info
        /// </summary>
        /// <remarks>
        /// {0} : current customer role IDs hash
        /// {1} : current store ID
        /// {2} : widget zone
        /// {3} : current theme name
        /// </remarks>
        public static CacheKey WidgetModelKey => new CacheKey("Bwr.pres.widget-{0}-{1}-{2}-{3}", WidgetPrefixCacheKey);
        public static string WidgetPrefixCacheKey => "Bwr.pres.widget";

    }
}
