namespace EASolution.DataMigration
{
    using FluentMigrator;
    using Infrastructure.MigrationTool;
    [Migration(201512220304)]
    [Profile("EASolution")]
    public class M201512220304_CreateFactoryTables : Migration
    {
        private bool exiting = false;

        public override void Up()
        {

            if (!Schema.Table("Factory").Exists())
            {
                Create.Table("Factory")
                    .WithCommonColumns()
                    .WithRequiredIntColumn("Type")
                    .WithRequiredIntColumn("Weight")
                    .WithRequiredIntColumn("Value")
                    .WithRequiredIntColumn("WeightedValue")
                    .WithForeignKeyColumn("Project", "Factory")
                    .WithAuditableColumns()
                    .WithRowVersionColumns();

                this.SeedFactoryCategory();
            }
            else
            {
                exiting = true;
            }
        }

        public override void Down()
        {
            if(!exiting)
                Delete.Table("Factory");
        }
    }
}
