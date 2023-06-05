using Microsoft.Extensions.Logging;
using TestConsoleApp.Core.Models;
using TestConsoleApp.Core.Services.Interfaces;

namespace TestConsoleApp.Core.Services
{
    internal class DisplayService : IDisplayService
    {
        private readonly ILogger _logger;

        public DisplayService(ILogger<DisplayService> logger)
        {
            ArgumentNullException.ThrowIfNull(logger);
            _logger = logger;
        }

        public void Show(List<Repository> repositories)
        {
            foreach (var rep in repositories)
            {
                Show(rep);
            }
        }

        private void Show(Repository repository)
        {
            _logger.LogInformation($"\n" +
                $"Repository:\n" +
                $"Name: {repository.Name}\n" +
                $"Description: {repository.Description}\n");
        }
    }
}
