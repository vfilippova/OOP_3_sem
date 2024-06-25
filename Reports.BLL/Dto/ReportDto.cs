using Reports.DAL.Reports;

namespace Reports.BLL.Dto;

public record ReportDto(ReportInfo ReportInfo, ReportMessageList ReportMessageList, int Id);