﻿using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Catalog;

namespace Bwr.Data.Mapping.Builders.Catalog
{
    /// <summary>
    /// Represents a related product entity builder
    /// </summary>
    public partial class RelatedProductBuilder : NopEntityBuilder<RelatedProduct>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
        }

        #endregion
    }
}