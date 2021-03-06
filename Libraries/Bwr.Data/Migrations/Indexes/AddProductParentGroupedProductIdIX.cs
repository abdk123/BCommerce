using FluentMigrator;
using Bwr.Core.Domain.Catalog;

namespace Bwr.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 09:36:08:9037705")]
    public class AddProductParentGroupedProductIdIX : AutoReversingMigration
    {
        #region Methods         

        public override void Up()
        {
            Create.Index("IX_Product_ParentGroupedProductId").OnTable(nameof(Product))
                .OnColumn(nameof(Product.ParentGroupedProductId)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}