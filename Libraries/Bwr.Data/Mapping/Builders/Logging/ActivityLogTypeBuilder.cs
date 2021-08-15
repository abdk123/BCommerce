using FluentMigrator.Builders.Create.Table;
using Bwr.Core.Domain.Logging;

namespace Bwr.Data.Mapping.Builders.Logging
{
    /// <summary>
    /// Represents an activity log type entity builder
    /// </summary>
    public partial class ActivityLogTypeBuilder : NopEntityBuilder<ActivityLogType>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(ActivityLogType.SystemKeyword)).AsString(100).NotNullable()
                .WithColumn(nameof(ActivityLogType.Name)).AsString(200).NotNullable();
        }

        #endregion
    }
}