using System.Data;
using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Orders;
using Bwr.Data.Extensions;

namespace Bwr.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a recurring payment entity builder
    /// </summary>
    public partial class RecurringPaymentBuilder : NopEntityBuilder<RecurringPayment>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(RecurringPayment.InitialOrderId)).AsInt32().ForeignKey<Order>(onDelete: Rule.None);
        }

        #endregion
    }
}