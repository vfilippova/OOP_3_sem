using Reports.BLL.Dto;
using Reports.DAL.Contexts;
using Reports.DAL.Reports;

namespace Reports.Services.Services;

public interface IReportService
{
    public ReportsAppContext ReportsAppContext { get; }

    List<ReportDto> GetReports();
    public ReportDto CreateReport();
}