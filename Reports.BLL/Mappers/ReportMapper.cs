using Reports.BLL.Dto;
using Reports.DAL.Reports;

namespace Reports.BLL.Mappers;

public static class ReportMapper
{
    public static ReportDto Map(Report report)
    {
        return new ReportDto(report.ReportInfo, report.ReportMessageList, report.Id);
    }
}