using FluentMigrator;
using Bwr.Data.Migrations;
using Bwr.Plugin.Tax.FixedOrByCountryStateZip.Domain;

namespace Bwr.Plugin.Tax.FixedOrByCountryStateZip.Data
{
    [SkipMigrationOnUpdate]
    [NopMigration("2020/02/03 09:27:23:6455432", "Tax.FixedOrByCountryStateZip base schema")]
    public class SchemaMigration : AutoReversingMigration
    {
        protected IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        public override void Up()
        {
            _migrationManager.BuildTable<TaxRate>(Create);
        }
    }
}