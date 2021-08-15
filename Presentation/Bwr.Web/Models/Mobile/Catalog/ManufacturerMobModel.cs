﻿using System.Collections.Generic;
using Bwr.Web.Framework.Models;
using Bwr.Web.Models.Mobile.Media;

namespace Bwr.Web.Models.Mobile.Catalog
{
    public partial class ManufacturerMobModel : BaseNopEntityModel
    {
        public ManufacturerMobModel()
        {
            PictureModel = new PictureMobModel();
            FeaturedProducts = new List<ProductOverviewMobModel>();
            Products = new List<ProductOverviewMobModel>();
            PagingFilteringContext = new CatalogPagingFilteringMobModel();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SeName { get; set; }

        public PictureMobModel PictureModel { get; set; }

        public CatalogPagingFilteringMobModel PagingFilteringContext { get; set; }

        public IList<ProductOverviewMobModel> FeaturedProducts { get; set; }
        public IList<ProductOverviewMobModel> Products { get; set; }
    }
}