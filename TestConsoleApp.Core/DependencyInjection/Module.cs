using Microsoft.Extensions.DependencyInjection;
using TestConsoleApp.Core.Services;
using TestConsoleApp.Core.Services.Interfaces;

namespace TestConsoleApp.Core.DependencyInjection
{
    public static class Module
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IDisplayService, DisplayService>();
            services.AddTransient<IGithubService, GithubService>();
            services.AddTransient<IRepositoryService, RepositoryService>();
            services.AddTransient<HttpClient>();
            return services;
        }
    }
}
