namespace EASolution.DataMigration
{
    using FluentMigrator;
    using Infrastructure.MigrationTool;
    [Migration(201512220329)]
    [Profile("EASolution")]
    public class M201512220329_CreateProjectTaskTables : Migration
    {
        bool exiting = false;

        public override void Up()
        {
            if (!Schema.Table("ProjectTask").Exists())
            {
                Create.Table("ProjectTask")
                       .WithCommonColumns()
                       .WithRequiredIntColumn("UseCase")
                       .WithRequiredIntColumn("UseCaseWeight")
                       .WithRequiredIntColumn("Actor")
                       .WithRequiredIntColumn("ActorWeight")
                       .WithRequiredIntColumn("Estimate")
                       .WithForeignKeyColumn("Project", "ProjectTask")
                       .WithAuditableColumns()
                       .WithRowVersionColumns();
            }
            else
            {
                exiting = true;
            }
        }

        public override void Down()
        {
            if(exiting)
                Delete.Table("ProjectTask");
        }
    }
}
