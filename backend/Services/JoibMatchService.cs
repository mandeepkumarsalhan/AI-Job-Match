using backend.DTOs;
namespace backend.Services;

public class JobMatchService
{
    public List<JobMatchDto> MatchJobs(List<NavJobDto> jobs,string userProfile)
    {
        var keywords = userProfile
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(k => k.Length > 2)
            .ToList();
        var result = new List<JobMatchDto>();
        foreach (var job in jobs)
        {
            int score = 0;
           var title = job.Title.ToLower();
            var company = job.Company.ToLower();
            foreach (var keyword in keywords)
            {
                if (title.Contains(keyword))
                {
                    score += 40;   // strong match
                }
                else if (company.Contains(keyword))
                {
                    score += 10;   // weak match
                }
                result.Add(new JobMatchDto
                {
                    Title = job.Title,
                    Company = job.Company,
                    Location = job.Location,
                    Score = score
                });
            }

        }
        return result
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .ToList();
    }
}