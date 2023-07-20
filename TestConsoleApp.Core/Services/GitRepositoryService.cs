using Microsoft.Extensions.Logging;
using TestConsoleApp.Core.Services.Interfaces;

namespace TestConsoleApp.Core.Services
{
    internal class GitRepositoryService : IGitRepositoryService
    {
        private readonly IDisplayService _displayService;
        private readonly IGithubService _githubService;
        private readonly ILogger<GitRepositoryService> _logger;

        public GitRepositoryService(IDisplayService displayService, IGithubService githubService, ILogger<GitRepositoryService> logger)
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

            var gitRepositories = await _githubService.GetRepositoriesAsync();

            // here can be a database repository
            //
            // _databaseRepository.SaveAsync(gitRepositories);

            _displayService.Show(gitRepositories);
            _displayService.Show(gitRepositories.Where(x => x.Language == "C#"), "Show only C# repositories");
        }
    }
}
