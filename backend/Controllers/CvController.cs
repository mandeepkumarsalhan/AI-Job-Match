
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CvController : ControllerBase
{
    private readonly PdfService _pdfService;
    public CvController(PdfService pdfService)
    {
        _pdfService = pdfService;
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
        return Ok(new
        {
            fileName = file.FileName,
            extractedText = text
        } );
    }
}