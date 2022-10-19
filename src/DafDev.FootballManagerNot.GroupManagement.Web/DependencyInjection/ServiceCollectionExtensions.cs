using DafDev.FootballManagerNot.Business.Services;
using DafDev.FootballManagerNot.GroupManagement.Contracts.Services;
using DafDev.FootballManagerNot.GroupManagement.Web.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddSingleton<IGroupService, InMemoryGroupService>();
        return services;
    }

    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<SomeRootConfiguration>(config.GetSection(SomeRootConfiguration.SomeRoot));
        services.Configure<FootballSecretsConfiguration>(config.GetSection(FootballSecretsConfiguration.FootballSecrets));
        return services;
    }
}
