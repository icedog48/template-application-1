using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations.Helpers
{
    public static class Runner
    {
        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }

            public string ProviderSwitches { get; set; }

            public int Timeout { get; set; }
        }

        public static void MigrateToLatest<TFactory>(string connectionString, MigrationOptions options = null) where TFactory : MigrationProcessorFactory
        {
            var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));

            var assembly = typeof(Runner).Assembly;

            var migrationContext = new RunnerContext(announcer);

            if (options == null) options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };

            var factory = Activator.CreateInstance<TFactory>(); 

            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }
    }
}
