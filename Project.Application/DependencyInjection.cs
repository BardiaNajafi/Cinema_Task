using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Services;

namespace Project.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {

        Services.AddScoped<IMovieService,MovieService>();

        Services.AddScoped<IRoomService,RoomService>();

        return Services;
    }
}