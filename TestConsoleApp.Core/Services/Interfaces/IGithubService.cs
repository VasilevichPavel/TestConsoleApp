using TestConsoleApp.Core.Models;

namespace TestConsoleApp.Core.Services.Interfaces
{
    public interface IGithubService
    {
        Task<List<Repository>> GetRepositoriesAsync();
    }
}
