using RestSharp;
namespace GithubApi.Repositories;
public class RepositoriesRepository : IRepositoriesRepository
{
    public async Task<RepositoriesApiResponse> GetHighlightsRepositoriesFromLanguage(string language)
    {
        var options = new RestClientOptions("https://api.github.com");
        var client = new RestClient(options);
        var response = await client.GetJsonAsync<RepositoriesApiResponse>($"/search/repositories?q=language:{language}&sort=stars&order=desc&per_page=5");
        return response;
    }
}