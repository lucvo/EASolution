namespace EASolution.DataMigration
{
    using FluentMigrator;
    using Infrastructure.MigrationTool;
    [Migration(201512220246)]
    [Profile("EASolution")]
    public class M201512220246_CreateUseCaseCategoryAndActorCategoryTables : Migration
    {
        public override void Up()
        {
            if (!Schema.Table("UseCaseCategory").Exists())
            {
                Create.Table("UseCaseCategory")
                    .WithIdColumn()
                    .WithRequiredIntColumn("Type")
                    .WithRequiredStringColumn("Description", 500)
                    .WithRequiredIntColumn("Weight")
                    .WithForeignKeyColumn("Project", "UserCaseCategory")
                    .WithAuditableColumns()
                    .WithRowVersionColumns();
                this.SeedUseCaseCategory();
            }

            if (!Schema.Table("ActorCategory").Exists())
            {
                Create.Table("ActorCategory")
                    .WithIdColumn()
                    .WithRequiredIntColumn("Type")
                    .WithRequiredStringColumn("Description", 500)
                    .WithRequiredIntColumn("Weight")
                    .WithForeignKeyColumn("Project", "ActorCategory")
                    .WithAuditableColumns()
                    .WithRowVersionColumns();

                this.SeedActorCategory();
            }
        }

        public override void Down()
        {
            Delete.Table("UseCaseCategory");
            Delete.Table("ActorCategory");
        }
    }
}
