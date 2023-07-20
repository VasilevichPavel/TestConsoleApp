using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestConsoleApp.Core.Services.Interfaces;

IServiceCollection services = new ServiceCollection();

Startup startup = new();
startup.ConfigureServices(services);
IServiceProvider serviceProvider = services.BuildServiceProvider();

var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger<Program>();
ArgumentNullException.ThrowIfNull(logger);
await TryCallServicesAsync();


async Task TryCallServicesAsync()
{
    logger.LogInformation("Start");

    try
    {
        await CallServicesAsync();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "ERROR");
    }

    logger.LogInformation("End");
}

async Task CallServicesAsync()
{
    var gitRepositoriesService = serviceProvider.GetService<IGitRepositoryService>();
    ArgumentNullException.ThrowIfNull(gitRepositoriesService);

    await gitRepositoriesService.LaunchAsync();
}
