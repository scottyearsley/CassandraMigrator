using System.Collections.Generic;
using CassandraMigrator.CommandConfiguration;
using CassandraMigrator.Commands;
using Microsoft.Extensions.CommandLineUtils;

namespace CassandraMigrator
{
    public class CommandLineOptions
    {
        public static CommandLineOptions Parse(string[] args)
        {
            var options = new CommandLineOptions();

            var app = new CommandLineApplication
            {
                Name = "cassandra-migrate",
                FullName = ".NET Core Cassandra migrator"
            };

            app.HelpOption("-?|-h|--help");

            var hosts = app.Option("-H|--host",
                "The cassandra hosts to connect to",
                CommandOptionType.MultipleValue);

            var port = app.Option("-p|--port",
                "The cassandra port",
                CommandOptionType.SingleValue);

            var user = app.Option("-u|--user",
                "The username",
                CommandOptionType.SingleValue);
            
            var password = app.Option("-P|--password",
                "The username",
                CommandOptionType.SingleValue);

            RootCommandConfiguration.Configure(app, options);

            var result = app.Execute(args);

            if (result != 0)
            {
                return null;
            }

            options.Host = hosts.Values;
            options.Port = port.Value();
            options.Username = user.Value();
            options.Password = password.Value();

            return options;
        }

        public ICommand Command { get; set; }
        
        public List<string> Host { get; set; }

        public string Port { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}