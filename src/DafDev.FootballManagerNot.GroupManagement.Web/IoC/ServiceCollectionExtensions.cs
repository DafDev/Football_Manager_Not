using DafDev.FootballManagerNot.Business.Services;
using DafDev.FootballManagerNot.GroupManagement.Contracts.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IGroupService, InMemoryGroupService>();
        return services;
    }
}
