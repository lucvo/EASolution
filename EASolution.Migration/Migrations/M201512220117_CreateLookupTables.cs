using EASolution.Infrastructure.Utility;

namespace EASolution.DataMigration
{
    using FluentMigrator;
    using FluentMigrator.Runner.Extensions;
    using Infrastructure.MigrationTool;
    [Migration(201512220117)]
    [Profile("EASolution")]
    public class M201512220117_CreateLookupTables : AutoReversingMigration
    {
        public override void Up()
        {
            if (!Schema.Table("CategoryType").Exists())
            {
                Create.Table("CategoryType")
                    .WithIdColumn()
                    .WithRequiredStringColumn("Name", 15)
                    .WithRequiredIntColumn("Type")
                    .WithRowVersionColumns();

                Insert.IntoTable("CategoryType").WithIdentityInsert().Row(new { Id = 1, Name = "Simple", Type = (int)Domain.CategoryType.UseCase });
                Insert.IntoTable("CategoryType").WithIdentityInsert().Row(new { Id = 2, Name = "Average", Type = (int)Domain.CategoryType.UseCase });
                Insert.IntoTable("CategoryType").WithIdentityInsert().Row(new { Id = 3, Name = "Complex", Type = (int)Domain.CategoryType.UseCase });

                Insert.IntoTable("CategoryType").WithIdentityInsert().Row(new { Id = 4, Name = "Simple", Type = (int)Domain.CategoryType.Actor });
                Insert.IntoTable("CategoryType").WithIdentityInsert().Row(new { Id = 5, Name = "Average", Type = (int)Domain.CategoryType.Actor });
                Insert.IntoTable("CategoryType").WithIdentityInsert().Row(new { Id = 6, Name = "Complex", Type = (int)Domain.CategoryType.Actor });
            }

            if (!Schema.Table("FactoryType").Exists())
            {
                Create.Table("FactoryType")
                    .WithIdColumn()
                    .WithRequiredStringColumn("Name", 15)
                    .WithRowVersionColumns();

                Insert.IntoTable("FactoryType").WithIdentityInsert().Row(new { Id = 1, Name = "Technical" });
                Insert.IntoTable("FactoryType").WithIdentityInsert().Row(new { Id = 2, Name = "Environment" });
            }
        }
    }
}
