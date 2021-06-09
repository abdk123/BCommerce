using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Caching;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Seo;
using Nop.Services.Topics;
using Nop.Services.Vendors;
using Nop.Web.Infrastructure.Cache;
using Nop.Web.Models.Catalog;
using Nop.Web.Models.Media;
using Nop.Web.Models.Mobile.Catalog;
using Nop.Web.Models.Mobile.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Web.Factories.Mobile
{
    public partial class CatalogMobFactory : ICatalogMobFactory
    {
        #region Fields

        private readonly ICatalogModelFactory _catalogModelFactory;
        

        #endregion

        #region Ctor

        public CatalogMobFactory(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }

        #endregion

        #region Categories

        /// <summary>
        /// Prepare homepage category models
        /// </summary>
        /// <returns>List of homepage category models</returns>
        public List<CategoryMobModel> PrepareHomepageCategoryModels()
        {
            var model = _catalogModelFactory.PrepareHomepageCategoryModels().Select(x => new CategoryMobModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Picture = x.PictureModel == null ? null : new PictureMobModel()
                {
                    AlternateText = x.PictureModel.AlternateText,
                    Title = x.PictureModel.Title,
                    ImageUrl = x.PictureModel.ImageUrl
                }
            }).ToList();
            
            return model;
        }


        /// <summary>
        /// Prepare category (simple) models
        /// </summary>
        /// <returns>List of category (simple) models</returns>
        public List<CategorySimpleMobModel> PrepareCategorySimpleModels()
        {
            var models = _catalogModelFactory.PrepareCategorySimpleModels().Select(x => new CategorySimpleMobModel()
            {
                Id = x.Id,
                Name = x.Name,
                HaveSubCategories = x.HaveSubCategories,
                IncludeInTopMenu = x.IncludeInTopMenu,
                NumberOfProducts = x.NumberOfProducts,
                SubCategories = GetSubCategories(x)
            }).ToList();

            return models;

        }

        #endregion

        #region Helper Methods

        private List<CategorySimpleMobModel> GetSubCategories(CategorySimpleModel model)
        {
            var list = new List<CategorySimpleMobModel>();

            if (model.SubCategories != null && model.SubCategories.Any())
            {
                foreach(var subCategory in model.SubCategories)
                {
                    var mobModel = new CategorySimpleMobModel()
                    {
                        Id = subCategory.Id,
                        Name = subCategory.Name,
                        HaveSubCategories = subCategory.HaveSubCategories,
                        IncludeInTopMenu = subCategory.IncludeInTopMenu,
                        NumberOfProducts = subCategory.NumberOfProducts,
                        SubCategories = GetSubCategories(subCategory)
                    };

                    list.Add(mobModel);
                }
            }

            return list;
        }

        #endregion

    }
}
