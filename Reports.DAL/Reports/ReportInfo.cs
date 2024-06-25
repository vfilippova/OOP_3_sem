using Microsoft.EntityFrameworkCore;

namespace Reports.DAL.Reports;

public class ReportInfo
{
    public ReportInfo(DateTime dateTime)
    {
        DateTime = dateTime;
    }

    public ReportInfo()
    {
    }

    public DateTime DateTime { get; set; }
}