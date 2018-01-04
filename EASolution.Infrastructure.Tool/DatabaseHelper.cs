using System.Data.SqlClient;

namespace EASolution.Infrastructure.MigrationTool
{
    public class DatabaseHelper
    {
        public string ConnectionString { get; protected set; }

        public DatabaseHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public static void CreateIfNotExists(string connectionString)
        {
            new DatabaseHelper(connectionString).CreateIfNotExists();
        }

        public void CreateIfNotExists()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(ConnectionString);
            var databaseName = connectionStringBuilder.InitialCatalog;

            connectionStringBuilder.InitialCatalog = "master";

            using (var connection = new SqlConnection(connectionStringBuilder.ToString()))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = string.Format("select * from master.dbo.sysdatabases where name='{0}'", databaseName);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) // exists
                            return;
                    }

                    command.CommandText = string.Format("CREATE DATABASE {0}", databaseName);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    
}