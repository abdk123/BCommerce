using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Directory;
using Bwr.Core.Domain.Shipping;
using Bwr.Data.Extensions;

namespace Bwr.Data.Mapping.Builders.Shipping
{
    /// <summary>
    /// Represents a shipping method country mapping entity builder
    /// </summary>
    public partial class ShippingMethodCountryMappingBuilder : NopEntityBuilder<ShippingMethodCountryMapping>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(ShippingMethodCountryMapping), nameof(ShippingMethodCountryMapping.ShippingMethodId)))
                    .AsInt32().PrimaryKey().ForeignKey<ShippingMethod>()
                .WithColumn(NameCompatibilityManager.GetColumnName(typeof(ShippingMethodCountryMapping), nameof(ShippingMethodCountryMapping.CountryId)))
                    .AsInt32().PrimaryKey().ForeignKey<Country>();
        }

        #endregion
    }
}