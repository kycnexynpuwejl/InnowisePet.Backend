using MongoDB.Bson;
using MongoDB.Driver;

namespace InnowisePet.Services.Report.DAL;

public class ReportPdfRepository
{
    private readonly IMongoCollection<ReportPdfModel> _reportPdfCollection;

    public ReportPdfRepository()
    {
        MongoClient client = new("mongodb://localhost:27017");
        IMongoDatabase localDb = client.GetDatabase("report");
        IMongoCollection<ReportPdfModel> _reportPdfCollection = localDb.GetCollection<ReportPdfModel>("pdfcollection");
    }

    public async Task AddReportPdf(ReportPdfModel report)
    {
        await _reportPdfCollection.InsertOneAsync(report);
    }
}