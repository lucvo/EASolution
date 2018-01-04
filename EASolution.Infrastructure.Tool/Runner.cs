using EASolution.Infrastructure.MigrationTool;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EASolution.Infrastructure.MigrationTool
{
    public class Runner
    {
        public static void Run(string[] args, Assembly assembly, string profile = "default")
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options) == false)
            {
                log.Fatal("Problem parsing options!");
            }

            log.Information("Processing migrations");
            var connectionStringVal = ConfigurationManager.ConnectionStrings[options.ConnectionStringName];
            if (connectionStringVal == null)
            {
                log.Fatal("ERROR: Unable to get connection string from configuration");
                
            }

            var connectionString = connectionStringVal.ConnectionString;
            log.Debug("Connection string is {connectionString}", connectionString);

            DatabaseHelper.CreateIfNotExists(connectionString);

            var runner = new Migrator(connectionString, assembly,profile);

            try
            {
                runner.MigrateToLatest();
            }
            catch (Exception e)
            {
                log.Fatal(e, "ERROR: problem while running migrations!");
            }

            log.Information("Migrations run successfully");
        }
    }
}
