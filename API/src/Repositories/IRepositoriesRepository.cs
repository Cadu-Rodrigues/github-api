
using API.Models;

public interface IRepositoriesRepository
{
    Task<RepositoriesApiResponse> GetHighlightsRepositoriesFromLanguage(string language);
    Task<List<Language>> GetHighlightsRepositoriesFromApi(string[] languages);
    List<Language> GetHighlightsRepositoriesFromMemory();
    void SaveHighlightsRepositories(List<Language> languages);
}