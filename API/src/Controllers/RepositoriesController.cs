using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class RepositoriesController : ControllerBase
{
    private readonly IRepositoriesRepository _repositoriesRepository;
    public RepositoriesController(IRepositoriesRepository repositoriesRepository)
    {
        _repositoriesRepository = repositoriesRepository;
    }

    [HttpGet]
    public IActionResult GetHighlightsRepositories()
    {
        List<Language> response = _repositoriesRepository.GetHighlightsRepositoriesFromMemory();
        if (response == null)
            return NotFound();
        return Ok(response);
    }
}