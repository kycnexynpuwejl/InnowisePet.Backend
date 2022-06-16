using MongoDB.Driver;

namespace InnowisePet.Services.Report.DAL;

public class ReportPdfRepository
{
    private readonly IMongoCollection<ReportPdfModel> mongoCollection;

    public ReportPdfRepository()
    {
        MongoClient client = new("mongodb://localhost:27017");
        IMongoDatabase reportDb = client.GetDatabase("report");
        mongoCollection = reportDb.GetCollection<ReportPdfModel>("pdfcollection");
    }

    public async Task AddReportPdf(ReportPdfModel report)
    {
        await mongoCollection.InsertOneAsync(report);
    }
}