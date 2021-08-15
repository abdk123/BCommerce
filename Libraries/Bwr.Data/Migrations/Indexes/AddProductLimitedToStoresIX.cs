using FluentMigrator;
using Bwr.Core.Domain.Catalog;

namespace Bwr.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 11:35:09:1647933")]
    public class AddProductLimitedToStoresIX : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Index("IX_Product_LimitedToStores").OnTable(nameof(Product))
                .OnColumn(nameof(Product.LimitedToStores)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}