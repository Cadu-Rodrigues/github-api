
using API.Models;

public sealed class SaveRepositoriesWorker : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private Timer _timer;
    public SaveRepositoriesWorker(IServiceProvider serviceProvider){
        _serviceProvider = serviceProvider;
        _timer = new Timer(GetData, null, TimeSpan.Zero, TimeSpan.FromSeconds(200));
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async void GetData(object? state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            IRepositoriesRepository repository = scope.ServiceProvider.GetRequiredService<IRepositoriesRepository>();
            string[] languages = { "java", "javascript", "ruby", "python", "csharp" };
            List<Language> response = await repository.GetHighlightsRepositoriesFromApi(languages);
            repository.SaveHighlightsRepositories(response);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}