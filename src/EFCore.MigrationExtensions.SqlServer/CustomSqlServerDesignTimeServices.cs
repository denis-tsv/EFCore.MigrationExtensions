using EFCore.MigrationExtensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.MigrationExtensions.SqlServer;

/// <summary> Services necessary to create migrations </summary>
public class CustomSqlServerDesignTimeServices : CustomDesignTimeServices
{
    /// <inheritdoc />
    public override void ConfigureDesignTimeServices(IServiceCollection services)
    {
        ReplaceBySingleton<IAnnotationCodeGenerator, CustomSqlServerAnnotationCodeGenerator>(services);
        base.ConfigureDesignTimeServices(services);
    }
}