namespace backend.DTOs;

public class SkillMatchResultDto
{
    public string Title { get; set;} = string.Empty;
    public string Company { get; set;} = string.Empty;
    public string Location { get; set;} = string.Empty;
    public int Score {get; set;}

    public List<string> MatchedSkills {get; set;} = new();
}