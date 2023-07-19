using Microsoft.Extensions.Logging;
using TestConsoleApp.Core.Services.Interfaces;

namespace TestConsoleApp.Core.Services
{
    internal class RepositoryService : IRepositoryService
    {
        private readonly IDisplayService _displayService;
        private readonly IGithubService _githubService;
        private readonly ILogger<RepositoryService> _logger;

        public RepositoryService(IDisplayService displayService, IGithubService githubService, ILogger<RepositoryService> logger)
        {
            ArgumentNullException.ThrowIfNull(displayService);
            _displayService = displayService;

            ArgumentNullException.ThrowIfNull(githubService);
            _githubService = githubService;

            ArgumentNullException.ThrowIfNull(logger);
            _logger = logger;
        }

        public async Task LaunchAsync()
        {
            _logger.LogInformation("Launch...");

            var repositories = await _githubService.GetRepositoriesAsync();

            // here is can be save in database service
            //
            // _domainService.SaveAsync(repositories);

            _displayService.Show(repositories);
            _displayService.Show(repositories.Where(x => x.Language == "C#"), "Show only C# repositories");
        }
    }
}
