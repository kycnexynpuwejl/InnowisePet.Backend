using Microsoft.EntityFrameworkCore;

namespace InnowisePet.Services.Report.DAL;

public class ReportDbContextSqLite : DbContext
{
    public ReportDbContextSqLite(DbContextOptions<ReportDbContextSqLite> options) : base(options) { }
}