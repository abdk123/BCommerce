using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Customers;
using Bwr.Data.Extensions;

namespace Bwr.Data.Mapping.Builders.Customers
{
    /// <summary>
    /// Represents a customer attribute value entity builder
    /// </summary>
    public partial class CustomerAttributeValueBuilder : NopEntityBuilder<CustomerAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerAttributeValue.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(CustomerAttributeValue.CustomerAttributeId)).AsInt32().ForeignKey<CustomerAttribute>();
        }

        #endregion
    }
}