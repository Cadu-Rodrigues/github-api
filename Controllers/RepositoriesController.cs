using Microsoft.AspNetCore.Mvc;

namespace GithubApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RepositoriesController : ControllerBase
{
    private readonly IRepositoriesRepository _repositoriesRepository;
    private RepositoryMapper mapper = new RepositoryMapper();
    public RepositoriesController(IRepositoriesRepository repositoriesRepository)
    {
        _repositoriesRepository = repositoriesRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetHighlightsRepositories()
    {
        List<HighlightsRepositoriesDTO> response = new List<HighlightsRepositoriesDTO>();
        string[] languages = { "java", "javascript", "ruby", "python", "csharp" };
        for (int i = 0; i < languages.Length; i++)
        {
            var model = await _repositoriesRepository.GetHighlightsRepositoriesFromLanguage(languages[i]);
            var repositories = mapper.convert(model);
            HighlightsRepositoriesDTO dto = new HighlightsRepositoriesDTO(){
                language = repositories[0].Language,
                repositories = repositories
            };
            response.Add(dto);
        }
        if (response == null)
            return NotFound();
        return Ok(response);
    }
}