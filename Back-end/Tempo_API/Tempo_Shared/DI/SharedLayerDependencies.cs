using Microsoft.Extensions.DependencyInjection;
using Tempo_Shared.Providers;

namespace Tempo_Shared.DI;

public static class SharedLayerDependencies
{
    public static void RegisterSharedDependencies(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
    }
}
