
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CvController : ControllerBase
{
    private readonly PdfService _pdfService;
      private readonly SkillExtractionService _skillService;
    public CvController(PdfService pdfService,
        SkillExtractionService skillService)
    {
        _pdfService = pdfService;
        _skillService = skillService;
    }
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if(file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded");
        }
        using var stream = file.OpenReadStream();
        var text = _pdfService.ExtractText(stream);
        var skills = _skillService.ExtractSkills(text);
        return Ok(new
        {
            fileName = file.FileName,
            skills = skills,
            rawTextLength = text.Length
        } );
    }
}