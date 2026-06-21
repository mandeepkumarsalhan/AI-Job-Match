using UglyToad.PdfPig;
namespace backend.Services;

public class PdfService
{
    public string ExtractText(Stream fileStream)
    {
        using var document = PdfDocument.Open(fileStream);
        var text = string.Empty;
        foreach(var page in document.GetPages())
        {
            text += page.Text + " ";
        }
        return text;
    }
}