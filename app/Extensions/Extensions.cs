using app.Data;
using app.Data.Repositories.Base;
using app.Infrastructure.Repositories.Base;
using app.Infrastructure.Services;
using app.Services;

namespace app.Extensions;
public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlServer<BlogDbContext>(configuration["ConnectionStrings:SqlServer"]);

        services.AddScoped<ArticleService>();
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
        return services;
    }
}
