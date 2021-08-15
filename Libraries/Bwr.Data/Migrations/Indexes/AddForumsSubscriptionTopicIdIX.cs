﻿using FluentMigrator;
using Bwr.Core.Domain.Forums;
using Bwr.Data.Mapping;

namespace Bwr.Data.Migrations.Indexes
{
    [NopMigration("2020/03/13 09:36:08:9037701")]
    public class AddForumsSubscriptionTopicIdIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            Create.Index("IX_Forums_Subscription_TopicId").OnTable(NameCompatibilityManager.GetTableName(typeof(ForumSubscription)))
                .OnColumn(nameof(ForumSubscription.TopicId)).Ascending()
                .WithOptions().NonClustered();
        }

        #endregion
    }
}