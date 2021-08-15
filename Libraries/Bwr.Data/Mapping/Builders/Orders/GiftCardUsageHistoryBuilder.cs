﻿using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Orders;
using Bwr.Data.Extensions;

namespace Bwr.Data.Mapping.Builders.Orders
{
    /// <summary>
    /// Represents a gift card usage history entity builder
    /// </summary>
    public partial class GiftCardUsageHistoryBuilder : NopEntityBuilder<GiftCardUsageHistory>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(GiftCardUsageHistory.GiftCardId)).AsInt32().ForeignKey<GiftCard>()
                .WithColumn(nameof(GiftCardUsageHistory.UsedWithOrderId)).AsInt32().ForeignKey<Order>();
        }

        #endregion
    }
}