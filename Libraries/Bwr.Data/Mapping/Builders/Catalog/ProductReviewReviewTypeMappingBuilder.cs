﻿using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Catalog;
using Bwr.Data.Extensions;

namespace Bwr.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a product review review type mapping entity builder
    /// </summary>
    public partial class ProductReviewReviewTypeMappingBuilder : NopEntityBuilder<ProductReviewReviewTypeMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ProductReviewReviewTypeMapping.ProductReviewId)).AsInt32().ForeignKey<ProductReview>()
                .WithColumn(nameof(ProductReviewReviewTypeMapping.ReviewTypeId)).AsInt32().ForeignKey<ReviewType>();
        }

        #endregion
    }
}
