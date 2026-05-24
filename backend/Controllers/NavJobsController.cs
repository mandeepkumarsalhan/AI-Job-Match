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
    public async Task<IActionResult> Get()
    {
        var jobs = await _navApiService.GetJobsAsync();
        return Ok(jobs);
    }
}