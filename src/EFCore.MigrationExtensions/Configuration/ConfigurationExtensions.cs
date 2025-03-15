using EFCore.MigrationExtensions.Generation;
using EFCore.MigrationExtensions.Generation.Contracts;
using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.MigrationExtensions.Configuration;

/// <summary> Configuration </summary>
public static class ConfigurationExtensions
{
    /// <summary> Add services used by DbContext internal container</summary>
    internal static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ICustomSqlGenerator, CreateOrUpdateSqlObjectSqlGenerator>();
        services.AddSingleton<ICustomSqlGenerator, DropSqlObjectSqlGenerator>();
        services.AddSingleton<IModelDiffer, SqlObjectsDiffer>();
    }

    /// <summary> Replaces services necessary for SQL objects </summary>
    public static void UseCommonSqlObjects(this DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ReplaceService<IMigrationsModelDiffer, CustomMigrationsModelDiffer>();

        ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(new SqlObjectsExtension());
    }
}