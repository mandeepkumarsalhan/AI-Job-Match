using backend.DTOs;
using backend.Integrations;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MatchController : ControllerBase
{
    private readonly NavApiService _navApiService;
    private readonly JobMatchService _matchService;

    public MatchController(NavApiService navApiService,JobMatchService matchService)
    {
        _navApiService = navApiService;
        _matchService = matchService;
    }
    [HttpGet]
    public async Task<IActionResult> Match([FromQuery] string profile)
    {
        var jobs = await _navApiService.GetJobsAsync();
        var result = _matchService.MatchJobs(jobs,profile);
        return Ok(result);
    }
    [HttpPost("skills")]
    public async Task<IActionResult> MatchSkills(
        SkillMatchResultDto request)
    {
        var jobs = await _navApiService.GetJobsAsync();
        var result = _matchService.MatchBySkills(
            jobs,
            request.MatchedSkills);
         return Ok(result);
    }
}