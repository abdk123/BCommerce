using FluentMigrator;
using Bwr.Core.Domain.Seo;

namespace Bwr.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 11:35:09:1647927")]
    public class AddUrlRecordSlugIX : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            Create.Index("IX_UrlRecord_Slug")
                .OnTable(nameof(UrlRecord))
                .OnColumn(nameof(UrlRecord.Slug))
                .Ascending()
                .WithOptions()
                .NonClustered();
        }

        #endregion
    }
}