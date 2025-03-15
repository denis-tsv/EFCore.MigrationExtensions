using EFCore.MigrationExtensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.MigrationExtensions.PostgreSQL;

/// <summary> Services necessary to create migrations </summary>
public class CustomNpgsqlDesignTimeServices : CustomDesignTimeServices
{
    /// <inheritdoc />
    public override void ConfigureDesignTimeServices(IServiceCollection services)
    {
        ReplaceBySingleton<IAnnotationCodeGenerator, CustomNpgsqlAnnotationCodeGenerator>(services);
        base.ConfigureDesignTimeServices(services);
    }
}