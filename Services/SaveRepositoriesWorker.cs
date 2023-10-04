public class SaveRepositoriesWorker : IHostedService
{
    private IRepositoriesRepository _repository;
    private Timer _timer;
    public SaveRepositoriesWorker(IRepositoriesRepository repository){
        _repository = repository;
        _timer = new Timer(GetData, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async void GetData(object? state)
    {
        string[] languages = { "java", "javascript", "ruby", "python", "csharp" };
        List<List<Repository>> response = await _repository.GetHighlightsRepositories(languages);
        _repository.SaveHighlightsRepositories(response);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}