using IronPdf;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace InnowisePet.Services.Report.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        HtmlToPdf renderer = new();
        PdfDocument? pdf = renderer.RenderHtmlAsPdf("<h1>Hello World<h1>").SaveAs("html-string.pdf");
        string connectionString = "mongodb://localhost:27017";
        MongoClient client = new(connectionString);
        IMongoDatabase database = client.GetDatabase("test");
        return Ok();
    }
}