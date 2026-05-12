using backend.Services;
using backend.Models;
using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly JobService _jobService;

    public JobsController()
    {
        _jobService = new JobService();
    }
    [HttpGet]
    public IActionResult GetJobs()
    {
        return Ok(_jobService.GetAll());
    }
    [HttpPost]
    public IActionResult CreateJob(CreateJobDto dto)
    {
        var job = new Job
        {
            Title = dto.Title,
            Company = dto.Company,
            Location = dto.Location,
            Description = dto.Description
        };

        var result = _jobService.Add(job);
        return Ok(result);
    }
}