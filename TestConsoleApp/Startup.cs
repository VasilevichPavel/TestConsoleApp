using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestConsoleApp.Core.DependencyInjection;
using TestConsoleApp.Core.Settings;

public class Startup
{
    IConfigurationRoot Configuration { get; }

    public Startup()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCoreServices();
        services.AddSingleton(Configuration);

        services.AddOptions<GithubSetting>()
            .Configure(options => Configuration
                .GetSection(nameof(GithubSetting))
                .Bind(options));

        services.AddLogging(factory => factory
            .AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Debug));
    }
}