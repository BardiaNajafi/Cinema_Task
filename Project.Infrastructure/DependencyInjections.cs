using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Data;
using Project.Infrastructure.Data;

namespace Project.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)

    {



        services.AddDbContext<ApplicationDbContext>((sp, config) =>
        {
            config.UseSqlServer(configuration.GetConnectionString("Database"));

           

        });

        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.("CinemaDb"));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }
}