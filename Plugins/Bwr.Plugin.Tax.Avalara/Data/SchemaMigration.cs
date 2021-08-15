using FluentMigrator;
using Bwr.Data.Migrations;
using Bwr.Plugin.Tax.Avalara.Domain;

namespace Bwr.Plugin.Tax.Avalara.Data
{
    [SkipMigrationOnUpdate]
    [NopMigration("2020/02/03 09:09:17:6455442", "Tax.Avalara base schema")]
    public class SchemaMigration : AutoReversingMigration
    {
        #region Fields

        protected IMigrationManager _migrationManager;

        #endregion

        #region Ctor

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            _migrationManager.BuildTable<TaxTransactionLog>(Create);
        }

        #endregion
    }
}