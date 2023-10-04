
public interface IRepositoriesRepository
{
     public Task<RepositoriesApiResponse> GetHighlightsRepositoriesFromLanguage(string language);
}