using InnowisePet.Models.DTO.Order;

namespace InnowisePet.Services.Report.BLL.Services;

public interface IGeneratePdfService
{
    void GeneratePdf(OrderAcceptedDto order);
    void GeneratePdfFromList(IEnumerable<OrderAcceptedDto> orderList);
}