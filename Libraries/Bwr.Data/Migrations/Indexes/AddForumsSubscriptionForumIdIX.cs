using FluentMigrator;
using Bwr.Core.Domain.Forums;
using Bwr.Data.Mapping;

namespace Bwr.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 09:36:08:9037700")]
    public class AddForumsSubscriptionForumIdIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_Forums_Subscription_ForumId").OnTable(NameCompatibilityManager.GetTableName(typeof(ForumSubscription)))
                .OnColumn(nameof(ForumSubscription.ForumId)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}