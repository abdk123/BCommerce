using FluentMigrator;
using Bwr.Core.Domain.Catalog;
using Bwr.Data.Mapping;

namespace Bwr.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 09:36:08:9037694")]
    public class AddProductProductAttributeMappingProductIdDisplayOrderIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_Product_ProductAttribute_Mapping_ProductId_DisplayOrder").OnTable(NameCompatibilityManager.GetTableName(typeof(ProductAttributeMapping)))
                .OnColumn(nameof(ProductAttributeMapping.ProductId)).Ascending()
                .OnColumn(nameof(ProductAttributeMapping.DisplayOrder)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}