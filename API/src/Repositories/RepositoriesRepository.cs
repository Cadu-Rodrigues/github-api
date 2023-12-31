using RestSharp;
using API.Data;
using API.Models;

namespace API.Repositories;
public class RepositoriesRepository : IRepositoriesRepository
{
    private RepositoryMapper mapper = new RepositoryMapper();
    private readonly RepositoriesContext _context;

    public RepositoriesRepository(RepositoriesContext context)
    {
        _context = context;
    }
    public async Task<RepositoriesApiResponse> GetHighlightsRepositoriesFromLanguage(string language)
    {
        var options = new RestClientOptions("https://api.github.com");
        var client = new RestClient(options);
        var response = await client.GetJsonAsync<RepositoriesApiResponse>($"/search/repositories?q=language:{language}&sort=stars&order=desc&per_page=5");
        return response;
    }
    public async Task<List<Language>> GetHighlightsRepositoriesFromApi(string[] languages)
    {
        List<Language> response = new List<Language>();
        for (int i = 0; i < languages.Length; i++)
        {
            var model = await GetHighlightsRepositoriesFromLanguage(languages[i]);
            List<Repository> repositories = mapper.convert(model);
            Language newLanguage = new Language()
            {
                Name = languages[i],
                Repositories = repositories,
            };
            response.Add(newLanguage);
        }
        return response;
    }
    public void SaveHighlightsRepositories(List<Language> languages)
    {
        foreach (Language language in languages)
        {
            var entity = _context.Languages.FirstOrDefault(l => l.ID == l.ID);
            if (entity is null)
                _context.Add(language);
            else
            {
                entity.Repositories = language.Repositories;
                _context.Update(entity);
            }
        }
        _context.SaveChanges();

    }
    public List<Language> GetHighlightsRepositoriesFromMemory()
    {
        List<Language> languages = _context.Languages.ToList();
        return languages;
    }
}