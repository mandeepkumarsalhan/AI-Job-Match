using backend.DTOs;
using backend.Models;

namespace backend.Interface;

public interface IJobService
{
    Task<List<Job>> GetAllJobsAsync();
    Task<Job> CreateJobAsync(CreateJobDto dto);
}