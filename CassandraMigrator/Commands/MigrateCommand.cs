using Microsoft.Extensions.CommandLineUtils;

namespace CassandraMigrator.Commands
{
    public class MigrateCommand: ICommand
    {
        public static void Configure(CommandLineApplication command) {

            command.Description = "Instruct the ninja to hide in a specific location.";
            command.HelpOption("-?|-h|--help");

            var locationArgument = command.Argument("[location]",
                "Where the ninja should hide.");

            command.OnExecute(() => {
                (new MigrateCommand()).Run();
                return 0;
            });
        }
        
        public int Run()
        {
            throw new System.NotImplementedException();
        }
    }
}