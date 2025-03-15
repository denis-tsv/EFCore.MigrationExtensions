using EFCore.MigrationExtensions.Utils;
using EFCore.MigrationExtensions.Generation;
using EFCore.MigrationExtensions.Generation.Contracts;
using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.MigrationExtensions.Configuration;

/// <summary> Services to create migrations </summary>
public class CustomDesignTimeServices : IDesignTimeServices
{
    /// <inheritdoc />
    public virtual void ConfigureDesignTimeServices(IServiceCollection services)
    {
        // replace EF Core services
        services.ReplaceBySingleton<IMigrationsCodeGenerator, CustomMigrationsGenerator>();
        services.ReplaceBySingleton<ICSharpMigrationOperationGenerator, CustomMigrationOperationGenerator>();
        services.ReplaceBySingleton<ICSharpSnapshotGenerator, CustomSnapshotGenerator>();

        // add some custom services: they are used by custom implementations of EF Core services, replaced higher
        services.AddSingleton<ICustomSnapshotGenerator, SqlObjectsSnapshotGenerator>();
        services.AddSingleton<IModelNamespaceProvider, SqlObjectsNamespaceProvider>();
        services.AddSingleton<ICustomMigrationOperationGenerator, CreateOrUpdateSqlObjectMigrationGenerator>();
        services.AddSingleton<ICustomMigrationOperationGenerator, DropSqlObjectMigrationGenerator>();
    }

    /// <summary> Replaces an existing service by singleton </summary>
    /// <remarks> Provides internal method to children </remarks>
    protected static void ReplaceBySingleton<TService, TNewService>(IServiceCollection services)
        where TService : class
        where TNewService : class, TService
    {
        services.ReplaceBySingleton<TService, TNewService>();
    }
}