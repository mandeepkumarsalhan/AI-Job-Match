using backend.Models;
using backend.Interface;
using backend.Data;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
namespace backend.Services;

public class JobService : IJobService
{
    private readonly AppDbContext _context;
    public JobService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Job>> GetAllJobsAsync()
    {
        return await _context.Jobs.ToListAsync();
    }
    public async Task<Job> CreateJobAsync(CreateJobDto dto)
    {
        var job = new Job
        {
            Title = dto.Title,
            Company = dto.Company,
            Location = dto.Location,
            Description = dto.Description
        };
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();
        return job;
    }
}