


namespace TenantStore.MigrationTool.Migrations
{
    using FluentMigrator;
    using EASolution.Infrastructure.MigrationTool;

    [Migration(201601232334)]
    [Profile("TenantStore")]
    public class M201601232334_CreateRoleTables : AutoReversingMigration
    {
        public override void Up()
        {
            string roleTableName = "AppRole";
            string userTabelName = "AppUser";
            if (!Schema.Table(roleTableName).Exists())
            {
                Create.Table(roleTableName)
                    .WithCommonColumns()
                    .WithRowVersionColumns();
            }

            if (!Schema.Table("UserRoles").Exists())
            {
                string tableName = "UserRoles";
                Create.Table(tableName)
                    .WithGuidIdColumn("AppUserId", false)
                    .ForeignKey(string.Format("FK_{0}_{1}", tableName, userTabelName), userTabelName, "Id")
                    .WithIdColumn("RoleId")
                    .ForeignKey(string.Format("FK_{0}_{1}", tableName, roleTableName), roleTableName, "Id")
                    .WithRowVersionColumns();

            }
        }
    }
}
