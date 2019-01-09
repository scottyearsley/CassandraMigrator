using CassandraMigrator.Commands;
using Microsoft.Extensions.CommandLineUtils;

namespace CassandraMigrator.CommandConfiguration
{
    public static class RootCommandConfiguration
    {
        public static void Configure(CommandLineApplication app, CommandLineOptions options)
        {
            app.Command("migrate", MigrateCommand.Configure);

            app.OnExecute(() =>
            {
                options.Command = new RootCommand(app);

                return 0;
            });

        }
    }
}