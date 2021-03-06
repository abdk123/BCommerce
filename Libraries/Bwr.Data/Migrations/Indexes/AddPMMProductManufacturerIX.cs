using FluentMigrator;
using Bwr.Core.Domain.Catalog;
using Bwr.Data.Mapping;

namespace Bwr.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 11:35:09:1647942")]
    public class AddPMMProductManufacturerIX : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Index("IX_PMM_Product_and_Manufacturer").OnTable(NameCompatibilityManager.GetTableName(typeof(ProductManufacturer)))
                .OnColumn(nameof(ProductManufacturer.ManufacturerId)).Ascending()
                .OnColumn(nameof(ProductManufacturer.ProductId)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}