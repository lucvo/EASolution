using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace EASolution.Infrastructure.MigrationTool
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithCommonColumns(this ICreateTableWithColumnSyntax table)
        {
            return table
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Description").AsString(500).Nullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithAuditableColumns(this ICreateTableWithColumnSyntax table)
        {
            return table
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("CreatedBy").AsString(255).NotNullable().WithDefaultValue("System")
                .WithColumn("UpdatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("UpdatedBy").AsString(255).NotNullable().WithDefaultValue("System");
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax WithRowVersionColumns(this ICreateTableWithColumnSyntax table)
        {
            return table
                .WithColumn("RowVersion").AsCustom("rowversion").NotNullable();
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string primaryKey="Id")
        {
            return tableWithColumnSyntax
                .WithColumn(primaryKey)
                .AsInt32()
                .NotNullable()
                .PrimaryKey()
                .Identity();
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax WithLongIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("Id")
                .AsInt64()
                .NotNullable()
                .PrimaryKey()
                .Identity();
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax WithGuidIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax,string colunmName="Id", bool WithDefault = true)
        {
            if (WithDefault)
                return tableWithColumnSyntax
                    .WithColumn(colunmName)
                    .AsGuid()
                    .NotNullable()
                    .PrimaryKey()
                    .WithDefault(SystemMethods.NewGuid);
            else
                return tableWithColumnSyntax
                .WithColumn(colunmName)
                .AsGuid()
                .NotNullable()
                .PrimaryKey();
        }
        
        public static ICreateTableColumnOptionOrWithColumnSyntax WithRequiredStringColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName, int maxLenght)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsString(maxLenght)
                .NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithRequiredIntColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsInt32()
                .NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithOptionalStringColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName, int maxLenght)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsString(maxLenght)
                .Nullable();
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax WithRequiredBitColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsBoolean()
                .NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithOptionalBitColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsBoolean()
                .Nullable();
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax WithOptionalIntColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsInt32()
                .Nullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithForeignKeyColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string primaryTable, string referenceTable)
        {
            return tableWithColumnSyntax
                .WithColumn(string.Format("{0}Id", primaryTable))
                .AsInt32()
                .ForeignKey(string.Format("FK_{0}_{1}", referenceTable, primaryTable), primaryTable, "Id")
                .NotNullable();
        }
        
        public static ICreateTableColumnOptionOrWithColumnSyntax WithForeignKeyLongColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string primaryTable, string referenceTable)
        {
            return tableWithColumnSyntax
                .WithColumn(string.Format("{0}Id", primaryTable))
                .AsInt64()
                .ForeignKey(string.Format("FK_{0}_{1}", referenceTable, primaryTable), primaryTable, "Id")
                .NotNullable();
        }
        public static ICreateTableColumnOptionOrWithColumnSyntax WithForeignKeyGuidColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string primaryTable, string referenceTable, string primaryKey="Id")
        {
            return tableWithColumnSyntax
                .WithColumn(string.Format("{0}Id", primaryTable))
                .AsGuid()
                .ForeignKey(string.Format("FK_{0}_{1}", referenceTable, primaryTable), primaryTable, primaryKey)
                .NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithRequiredDateTimeColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsDateTime()
                .NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithOptionalDateTimeColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax, string columnName)
        {
            return tableWithColumnSyntax
                .WithColumn(columnName)
                .AsDateTime()
                .Nullable();
        }

        
    }
}