namespace Reports.DAL.Reports;

public class Report
{
    public Report(ReportInfo reportInfo, ReportMessageList reportMessageList, int id)
    {
        ReportInfo = reportInfo;
        ReportMessageList = reportMessageList;
        Id = id;
    }

    public Report()
    {
    }

    public int Id { get; set; }
    public ReportInfo ReportInfo { get; set; }
    public ReportMessageList ReportMessageList { get; set; }
}