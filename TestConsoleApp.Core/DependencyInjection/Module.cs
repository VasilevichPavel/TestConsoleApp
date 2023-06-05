using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestConsoleApp.Core.Services;
using TestConsoleApp.Core.Services.Interfaces;
using TestConsoleApp.Core.Settings;

namespace TestConsoleApp.Core.DependencyInjection
{
    public static class Module
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IGithubService, GithubService>();
            services.AddTransient<IDisplayService, DisplayService>();
            services.AddTransient<HttpClient>();
            return services;
        }
    }
}
