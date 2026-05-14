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
    public async Task<Job?> GetJobByIdAsync(int id)
    {
        return await _context.Jobs.FirstOrDefaultAsync(j =>j.Id == id);
    }

    public async Task<Job?> UpdateJobAsync(int id, UpdateJobDto dto)
    {
        var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        System.Console.WriteLine($"Found Job: {job?.Title ?? "Null"} (ID: {job?.Id})");
        if (job == null) return null;

        job.Title = dto.Title;
        job.Company = dto.Company;
        job.Location = dto.Location;
        job.Description = dto.Description;

        await _context.SaveChangesAsync();
        return job;
    }
    public async Task<bool> DeleteJobAsync(int id)
    {
        var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
        if (job == null)
        {
            return false;
        }
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
        return true;
    }
}