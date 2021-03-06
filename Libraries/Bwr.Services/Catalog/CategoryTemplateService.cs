using System;
using System.Collections.Generic;
using System.Linq;
using Bwr.Core.Domain.Catalog;
using Bwr.Data;
using Bwr.Services.Caching;
using Bwr.Services.Caching.Extensions;
using Bwr.Services.Events;

namespace Bwr.Services.Catalog
{
    /// <summary>
    /// Category template service
    /// </summary>
    public partial class CategoryTemplateService : ICategoryTemplateService
    {
        #region Fields

        private readonly ICacheKeyService _cacheKeyService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<CategoryTemplate> _categoryTemplateRepository;

        #endregion

        #region Ctor

        public CategoryTemplateService(ICacheKeyService cacheKeyService,
        IEventPublisher eventPublisher,
            IRepository<CategoryTemplate> categoryTemplateRepository)
        {
            _cacheKeyService = cacheKeyService;
            _eventPublisher = eventPublisher;
            _categoryTemplateRepository = categoryTemplateRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual void DeleteCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            if (categoryTemplate == null)
                throw new ArgumentNullException(nameof(categoryTemplate));

            _categoryTemplateRepository.Delete(categoryTemplate);

            //event notification
            _eventPublisher.EntityDeleted(categoryTemplate);
        }

        /// <summary>
        /// Gets all category templates
        /// </summary>
        /// <returns>Category templates</returns>
        public virtual IList<CategoryTemplate> GetAllCategoryTemplates()
        {
            var query = from pt in _categoryTemplateRepository.Table
                        orderby pt.DisplayOrder, pt.Id
                        select pt;

            var templates = query.ToCachedList(_cacheKeyService.PrepareKeyForDefaultCache(NopCatalogDefaults.CategoryTemplatesAllCacheKey));

            return templates;
        }

        /// <summary>
        /// Gets a category template
        /// </summary>
        /// <param name="categoryTemplateId">Category template identifier</param>
        /// <returns>Category template</returns>
        public virtual CategoryTemplate GetCategoryTemplateById(int categoryTemplateId)
        {
            if (categoryTemplateId == 0)
                return null;

            return _categoryTemplateRepository.ToCachedGetById(categoryTemplateId);
        }

        /// <summary>
        /// Inserts category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual void InsertCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            if (categoryTemplate == null)
                throw new ArgumentNullException(nameof(categoryTemplate));

            _categoryTemplateRepository.Insert(categoryTemplate);

            //event notification
            _eventPublisher.EntityInserted(categoryTemplate);
        }

        /// <summary>
        /// Updates the category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        public virtual void UpdateCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            if (categoryTemplate == null)
                throw new ArgumentNullException(nameof(categoryTemplate));

            _categoryTemplateRepository.Update(categoryTemplate);

            //event notification
            _eventPublisher.EntityUpdated(categoryTemplate);
        }

        #endregion
    }
}