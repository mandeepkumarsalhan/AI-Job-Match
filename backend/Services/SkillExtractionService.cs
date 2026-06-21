using backend.Data;
namespace backend.Services;

public class SkillExtractionService
{
    public List<string> ExtractSkills(string text)
    {
        if(string.IsNullOrWhiteSpace(text))
        {
            return new List<string>();
        }
        var lowerText = text.ToLower();
        var foundSkills = new List<string>();
        foreach(var skill in SkillDictionary.Skills)
        {
            if(lowerText.Contains(skill.ToLower()))
            {
                foundSkills.Add(skill);
            }
        }
        return foundSkills.Distinct().ToList();
    }
}