using TestConsoleApp.Core.Models;
using TestConsoleApp.Core.Services.Interfaces;

namespace TestConsoleApp.Core.Services
{
    internal class DisplayService : IDisplayService
    {
        public void Show(IEnumerable<Repository> repositories)
        {
            var title = "Show all repositories";
            Show(repositories, title);
        }

        public void Show(IEnumerable<Repository> repositories, string title)
        {
            Console.WriteLine("\n" + title + "\n");

            foreach (var rep in repositories)
            {
                Show(rep);
            }
        }

        private void Show(Repository repository)
        {
            Console.WriteLine("\n" +
                "Repository:\n" +
                "Name: " + repository.Name + "\n" +
                "Description: " + repository.Description + "\n" +
                "Language: " + repository.Language + "\n" +
                "Html Url: " + repository.Url + "\n");
        }
    }
}
