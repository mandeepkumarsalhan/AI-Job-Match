using backend.DTOs;
namespace backend.Services;

public class JobMatchService
{
    public List<JobMatchDto> MatchJobs(List<NavJobDto> jobs,string userProfile)
    {
        var keywords = userProfile
            .ToLower()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //.Where(k => k.Length > 2)
            //.ToList();
        var result = new List<JobMatchDto>();
        foreach (var job in jobs)
        {
            int score = 0;
           var title = job.Title.ToLower() ?? "";
            var company = job.Company.ToLower() ?? "";
            var location = job.Location.ToLower() ?? "";
            foreach (var keyword in keywords)
            {
                if (title.Contains(keyword))
                {
                    score += 20;   // strong match
                }
                else if (company.Contains(keyword))
                {
                    score += 10;   // weak match
                }
                else if (location.Contains(keyword))
                {
                score += 5;
                }
                //Bonus: if multiple keywords match title
                int titleMatches = keywords.Count(k=> title.Contains(k));
                if(titleMatches >1)
                {
                    score +=10;
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
            .OrderByDescending(x => x.Score)
            .ToList();
    }
    public List<SkillMatchResultDto> MatchBySkills(
    List<NavJobDto> jobs,
    List<string> skills)
    {
    var results = new List<SkillMatchResultDto>();

    foreach (var job in jobs)
    {
        int score = 0;

        var matchedSkills = new List<string>();

        var text =
            $"{job.Title} {job.Company}"
            .ToLower();

        foreach (var skill in skills)
        {
            if (text.Contains(skill.ToLower()))
            {
                score += 25;

                matchedSkills.Add(skill);
            }
        }

        results.Add(new SkillMatchResultDto
        {
            Title = job.Title,
            Company = job.Company,
            Location = job.Location,
            Score = score,
            MatchedSkills = matchedSkills
        });
    }

    return results
        .OrderByDescending(x => x.Score)
        .ToList();
    }
}