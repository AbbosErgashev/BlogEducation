using Microsoft.EntityFrameworkCore;

namespace BlogEducation.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql
        (
            configuration.GetConnectionString("DefaultSqlServerConnection")
        ));

        services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
        services.AddTransient<IBlogRepository, BlogRepository>();
    }
}