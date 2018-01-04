using CommandLine;

namespace EASolution.Infrastructure.MigrationTool
{
    public class Options
    {
        [Option('n', "name", 
            HelpText = "Connection String name in configuration",
            DefaultValue = "default")]
        public string ConnectionStringName { get; set; }

        [Option('c', "create",
            HelpText = "Create database if not exists",
            DefaultValue = true)]
        public bool CreateDatabase { get; set; }
    }
}