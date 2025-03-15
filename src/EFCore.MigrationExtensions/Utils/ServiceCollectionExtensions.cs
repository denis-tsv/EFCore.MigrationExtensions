using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.MigrationExtensions.Utils;

internal static class ServiceCollectionExtensions
{
    /// <summary> Remove service </summary>
    public static void RemoveService<TService>(this IServiceCollection services) where TService : class
    {
        var descriptors = services.Where(s => s.ServiceType == typeof(TService)).ToArray();

        foreach (var descriptor in descriptors)
        {
            services.Remove(descriptor);
        }
    }

    /// <summary> Replace the previously registered service with singleton </summary>
    public static void ReplaceBySingleton<TService, TNewService>(this IServiceCollection services)
        where TService : class
        where TNewService : class, TService
    {
        services.RemoveService<TService>();
        services.AddSingleton<TService, TNewService>();
    }
}