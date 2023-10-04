using RestSharp;
namespace GithubApi.Repositories;
public class RepositoriesRepository : IRepositoriesRepository
{
    private RepositoryMapper mapper = new RepositoryMapper();
    private List<List<Repository>> internalRepository = new List<List<Repository>>();
    public async Task<RepositoriesApiResponse> GetHighlightsRepositoriesFromLanguage(string language)
    {
        var options = new RestClientOptions("https://api.github.com");
        var client = new RestClient(options);
        var response = await client.GetJsonAsync<RepositoriesApiResponse>($"/search/repositories?q=language:{language}&sort=stars&order=desc&per_page=5");
        return response;
    }
    public async Task<List<List<Repository>>> GetHighlightsRepositoriesFromApi(string[] languages)
    {
        List<List<Repository>> response = new List<List<Repository>>();
        for (int i = 0; i < languages.Length; i++)
        {
            var model = await GetHighlightsRepositoriesFromLanguage(languages[i]);
            var repositories = mapper.convert(model);
            response.Add(repositories);
        }
        return response;
    }
    public void SaveHighlightsRepositories(List<List<Repository>> repositories)
    {
        internalRepository = repositories;
    }
    public List<HighlightsRepositoriesDTO> GetHighlightsRepositoriesFromMemory()
    {
        List<HighlightsRepositoriesDTO> response = new List<HighlightsRepositoriesDTO>();
        foreach(List<Repository> list in internalRepository){
            HighlightsRepositoriesDTO dto = new HighlightsRepositoriesDTO()
            {
                language = list[0].Language,
                repositories = list
            };
            response.Add(dto);
        }
        return response;
    }
}