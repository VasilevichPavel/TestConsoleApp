using TestConsoleApp.Core.Models;

namespace TestConsoleApp.Core.Services.Interfaces
{
    public interface IDisplayService
    {
        void Show(List<Repository> repositories);
    }
}
