using backend.Models;

namespace backend.Services;

public class JobService
{
    private static List<Job> _jobs = new();

    public List<Job> GetAll()
    {
        return _jobs;
    }

    public Job Add(Job job)
    {
        job.Id = _jobs.Count + 1;
        _jobs.Add(job);
        return job;
    }
}