using backend.Services;
using backend.Models;
using backend.DTOs;
using backend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }
    [HttpGet]
    public async Task<IActionResult> GetJobs()
    {
        var jobs = await _jobService.GetAllJobsAsync();
        return Ok(jobs);
    }
    [HttpPost]
    public async Task<IActionResult> CreateJob(CreateJobDto dto)
    {
        var result = await _jobService.CreateJobAsync(dto);
        return Ok(result);
    }
}