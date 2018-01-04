
namespace EASolution.DataMigration
{
    using FluentMigrator;
    using FluentMigrator.Runner.Extensions;
    using Infrastructure.MigrationTool;
    using EASolution.Domain;
    [Migration(201512220237)]
    [Profile("EASolution")]
    public class M201512220237_CreateProjectTables : Migration
    {
        private bool exitingProject = false;

        public override void Up()
        {
            if (!Schema.Table("Project").Exists())
            {
                Create.Table("Project")
                    .WithCommonColumns()
                    .WithRequiredIntColumn("Unit")
                    .WithRequiredIntColumn("EffortPerPoint")
                    .WithOptionalDateTimeColumn("ApprovedDate")
                    .WithOptionalStringColumn("ApprovedBy", 255)
                    .WithAuditableColumns()
                    .WithRowVersionColumns();

                Insert.IntoTable("Project")
                .WithIdentityInsert()
                .Row(new
                {
                    Id = 1,
                    Name = "Sample",
                    Description = "Sample Project",
                    Unit = (int)EstimationUnit.Hour,
                    EffortPerPoint = 1
                });
            }
            else
            {
                exitingProject = true;
            }
        }

        public override void Down()
        {
            if (!exitingProject)
            {
                Delete.Table("Project");
            }
        }
    }
}
