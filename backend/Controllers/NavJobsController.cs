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
    public async Task<IActionResult> Get(
        [FromQuery] string? city,
        [FromQuery] string? search,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
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
        var totalItems = jobs.Count();
        var pageJobs = jobs
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToList();
        return Ok(new
        {
            totalItems,
            page,
            pageSize,
            totalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
            data = pageJobs
        });
    }
}