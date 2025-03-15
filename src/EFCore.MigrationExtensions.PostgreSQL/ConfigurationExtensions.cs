namespace EFCore.MigrationExtensions.PostgreSQL;

using EFCore.MigrationExtensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

/// <summary> Extensions for using SQL objects. </summary>
public static class ConfigurationExtensions
{
    /// <summary> Replaces some services necessary for SQL objects. </summary>
    public static void UseSqlObjects(this DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCommonSqlObjects();

        optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomNpgsqlMigrationsSqlGenerator>();
    }
}