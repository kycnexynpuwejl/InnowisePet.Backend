using InnowisePet.DTO.DTO.Order;
using IronPdf;

namespace InnowisePet.Services.Report.BLL.Services;

public class GeneratePdfService : IGeneratePdfService
{
    public void GeneratePdf(OrderAcceptedDto order)
    {
        HtmlToPdf renderer = new();
        PdfDocument? pdf = renderer.RenderHtmlAsPdf(
            $@"<h1>{order.Firstname} {order.Lastname}</h1>
                <h2>{order.Address}</h2>"
        ).SaveAs("single.pdf");
    }

    public void GeneratePdfFromList(IEnumerable<OrderAcceptedDto> orderList)
    {
        HtmlToPdf renderer = new();
        
        
        //TODO
        renderer.RenderHtmlAsPdf(
                $@"<h1></h1>");

        
    }
}