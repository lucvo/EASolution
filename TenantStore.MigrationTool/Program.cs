using EASolution.Infrastructure.MigrationTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantStore.MigrationTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Runner.Run(args, typeof(Program).Assembly,"TenantStore");
            Environment.Exit(0);
        }
    }
}
