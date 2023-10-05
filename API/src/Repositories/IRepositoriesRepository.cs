
public interface IRepositoriesRepository
{
    Task<RepositoriesApiResponse> GetHighlightsRepositoriesFromLanguage(string language);
    Task<List<List<Repository>>> GetHighlightsRepositoriesFromApi(string[] languages);
    List<HighlightsRepositoriesDTO> GetHighlightsRepositoriesFromMemory();
    void SaveHighlightsRepositories(List<List<Repository>> repositories);
}