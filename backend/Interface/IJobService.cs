using backend.DTOs;
using backend.Models;

namespace backend.Interface;

public interface IJobService
{
    Task<List<Job>> GetAllJobsAsync();
    Task<Job> CreateJobAsync(CreateJobDto dto);
    Task<Job?> GetJobByIdAsync(int id);
    Task<Job?> UpdateJobAsync(int id, UpdateJobDto dto);
    Task<bool> DeleteJobAsync(int id);
}