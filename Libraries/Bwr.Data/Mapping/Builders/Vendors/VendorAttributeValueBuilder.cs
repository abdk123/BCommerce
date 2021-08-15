using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Vendors;
using Bwr.Data.Extensions;

namespace Bwr.Data.Mapping.Builders.Vendors
{
    /// <summary>
    /// Represents a vendor attribute value entity builder
    /// </summary>
    public partial class VendorAttributeValueBuilder : NopEntityBuilder<VendorAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(VendorAttributeValue.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(VendorAttributeValue.VendorAttributeId)).AsInt32().ForeignKey<VendorAttribute>();
        }

        #endregion
    }
}