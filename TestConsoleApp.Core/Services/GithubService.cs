using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TestConsoleApp.Core.Exceptions;
using TestConsoleApp.Core.Models;
using TestConsoleApp.Core.Services.Interfaces;
using TestConsoleApp.Core.Settings;

namespace TestConsoleApp.Core.Services
{
    public class GithubService : IGithubService
    {
        private readonly HttpClient _httpClient;
        private readonly GithubSetting _githubSetting;
        private readonly ILogger<GithubService> _logger;

        public GithubService(HttpClient httpClient, IOptions<GithubSetting> githubOption, ILogger<GithubService> logger)
        {
            ArgumentNullException.ThrowIfNull(httpClient);
            _httpClient = httpClient;

            ArgumentNullException.ThrowIfNull(logger);
            _githubSetting = githubOption.Value;

            ConfigureHttpClient();

            ArgumentNullException.ThrowIfNull(logger);
            _logger = logger;
        }

        public async Task<List<Repository>> GetRepositoriesAsync()
        {
            _logger.LogInformation("Call API");

            var result = string.Empty;

            using (_httpClient)
            {
                result = await _httpClient.GetStringAsync(_githubSetting.API);
            }

            var models = JsonConvert.DeserializeObject<List<Repository>>(result);
            return models ?? throw new DeserializationException();
        }

        private void ConfigureHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_githubSetting.MediaType));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", _githubSetting.UserAgent);
        }
    }
}
