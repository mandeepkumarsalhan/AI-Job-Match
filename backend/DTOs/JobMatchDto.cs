namespace backend.DTOs;

public class JobMatchDto
{
    public string Title {get;set;} = string.Empty;
    public string Company {get;set;} = string.Empty;
    public string Location {get;set;} = string.Empty;
    public int Score {get;set;}
}