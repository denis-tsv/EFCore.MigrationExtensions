using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.MigrationExtensions.Configuration;

/// <summary> Add services to ServiceProvider in DbContext</summary>
internal class SqlObjectsExtension : IDbContextOptionsExtension
{
    /// <summary> Add services to ServiceProvider in DbContext</summary>
    public void ApplyServices(IServiceCollection services)
    {
        services.AddServices();
    }

    /// <summary>
    ///     Gives the extension a chance to validate that all options in the extension are valid.
    ///     Most extensions do not have invalid combinations and so this will be a no-op.
    ///     If options are invalid, then an exception should be thrown.
    /// </summary>
    /// <param name="options"> The options being validated. </param>
    public void Validate(IDbContextOptions options)
    {
    }

    /// <summary>Information/metadata about the extension.</summary>
    public DbContextOptionsExtensionInfo Info => new SqlObjectsExtensionInfo(this);
}