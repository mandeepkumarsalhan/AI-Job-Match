using backend.Integrations;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NavJobsController : ControllerBase
{
    private readonly NavApiService _navApiService;

    public NavJobsController(NavApiService navApiService)
    {
        _navApiService = navApiService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? city,[FromQuery] string? search)
    {
        var jobs = await _navApiService.GetJobsAsync();
        if(!string.IsNullOrWhiteSpace(city))
        {
            jobs = jobs.Where(j=> j.Location != null &&
            j.Location.Contains(city, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
        if(!string.IsNullOrWhiteSpace(search))
        {
            jobs = jobs.Where(j=> j.Title != null &&
            j.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
        return Ok(jobs);
    }
}