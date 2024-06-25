namespace Reports.DAL.Reports;

public class ReportMessageList
{
    public ReportMessageList()
    {
    }

    public ReportMessageList(List<string> messages)
    {
        Messages = messages;
    }

    public List<string> Messages { get; set; }
}