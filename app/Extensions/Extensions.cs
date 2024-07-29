using app.Business;
using app.Infrastructure;

namespace app.Extensions;
public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
        return services;
    }
}
