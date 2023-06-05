using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestConsoleApp.Core.Services.Interfaces;

IServiceCollection services = new ServiceCollection();

Startup startup = new();
startup.ConfigureServices(services);
IServiceProvider serviceProvider = services.BuildServiceProvider();

var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger<Program>();
ArgumentNullException.ThrowIfNull(logger);

logger.LogInformation("Start");

var githubService = serviceProvider.GetService<IGithubService>();
ArgumentNullException.ThrowIfNull(githubService);

var repositories = await githubService.GetRepositoriesAsync();

var showService = serviceProvider.GetService<IDisplayService>();
ArgumentNullException.ThrowIfNull(showService);

showService.Show(repositories);
