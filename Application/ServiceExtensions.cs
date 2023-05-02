using System.Reflection;
using AutoMapper;

namespace BlogEducation.Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IBlogService, BlogService>();
    }
}