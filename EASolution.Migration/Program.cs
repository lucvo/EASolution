using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using EASolution.Infrastructure.Utility;
using Serilog;
using EASolution.Infrastructure.MigrationTool;

namespace EASolution.DataMigration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Runner.Run(args, typeof(Program).Assembly,"EASolution");
            Environment.Exit(0);
        }
    }
}
