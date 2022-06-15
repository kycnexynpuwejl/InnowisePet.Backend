using InnowisePet.DTO.DTO.Order;
using InnowisePet.Services.Report.DAL;
using IronPdf;

namespace InnowisePet.Services.Report.BLL.Services;

public class GeneratePdfService : IGeneratePdfService
{
    private readonly ReportPdfRepository _repository;

    public GeneratePdfService(ReportPdfRepository repository)
    {
        _repository = repository;
    }

    public void GeneratePdf(OrderAcceptedDto order)
    {
        HtmlToPdf renderer = new();
        PdfDocument? pdf = renderer.RenderHtmlAsPdf(
            $@"<h1>{order.Firstname} {order.Lastname}</h1>
                <h2>{order.Address}</h2>"
        ).SaveAs($"{DateTime.Now.ToFileTime()}.pdf");
    }

    public void GeneratePdfFromList(IEnumerable<OrderAcceptedDto> orderList)
    {

        string productQuantity = @"<h1>Thanks for ordering!</h1>";
        string firstname = "";
        string lastname = "";
        foreach (OrderAcceptedDto order in orderList)
        {
            productQuantity += "<h2>Product: " + order.ProductName + "  Quantity: " + order.Quantity + "</h2>\n";
            firstname = order.Firstname;
            lastname = order.Lastname;
        }
        
        HtmlToPdf renderer = new();

        PdfDocument? pdf = renderer.RenderHtmlAsPdf(@$"
                                {productQuantity}
                                <h1>{firstname} {lastname}</h1>"
                                );
        
        pdf.SaveAs($"{DateTime.Now.ToFileTime()}.pdf");
        
        byte[]? binaryPdf = pdf.BinaryData;

        _repository.AddReportPdf(new ReportPdfModel() { PdfFile = binaryPdf });
    }
}