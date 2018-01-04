namespace EASolution.DataMigration
{
    using FluentMigrator;
    using Infrastructure.MigrationTool;
    [Migration(201512220335)]
    [Profile("TenantStore")]
    public class M201512220335_CreateUserTables : Migration
    {
        public override void Up()
        {
            if (!Schema.Table("Country").Exists())
            {
                Create.Table("Country")
                    .WithIdColumn()
                    .WithRequiredStringColumn("Name", 100)
                    .WithRowVersionColumns();
            }

            if (!Schema.Table("AppUser").Exists())
            {
                Create.Table("AppUser")
                    .WithGuidIdColumn()
                    .WithRequiredStringColumn("UserName", 255)
                    .WithRequiredStringColumn("Password", 255)
                    .WithRequiredStringColumn("Email", 255)
                    .WithRequiredBitColumn("Enable")
                    .WithAuditableColumns()
                    .WithRowVersionColumns();
            }
            if (!Schema.Table("Account").Exists())
            {
                string primaryTable = "AppUser";
                Create.Table("Account")
                    .WithGuidIdColumn("Id", false)
                    .ForeignKey(string.Format("FK_{0}_{1}", "Account", primaryTable), primaryTable, "Id")
                    .WithRequiredStringColumn("FirstName", 50)
                    .WithRequiredStringColumn("LastName", 50)
                    .WithRequiredStringColumn("Phone", 20)
                    .WithRequiredStringColumn("Address", 100)
                    .WithRequiredStringColumn("City", 50)
                    .WithRequiredStringColumn("ZipCode", 14)
                    .WithRequiredStringColumn("State", 50)
                    .WithRequiredStringColumn("Database", 255)
                    .WithForeignKeyColumn("Country", "Account")
                    .WithAuditableColumns()
                    .WithRowVersionColumns();
            }
        }

        public override void Down()
        {
        
            Delete.Table("Account");
            Delete.Table("Country");
            Delete.Table("AppUser");
        }
    }
}
