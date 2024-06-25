using Reports.BLL.Dto;
using Reports.BLL.Mappers;
using Reports.DAL.Contexts;
using Reports.DAL.Messages;
using Reports.DAL.Reports;
using Reports.Services.Services;

namespace Reports.Services.Entities;

public class ReportService : IReportService
{
    private static int _counter = 0;

    public ReportService(ReportsAppContext reportsAppContext)
    {
        ReportsAppContext = reportsAppContext;
    }

    public ReportsAppContext ReportsAppContext { get; }

    public List<ReportDto> GetReports()
    {
        return ReportsAppContext.Reports.Select(x => ReportMapper.Map(x)).ToList();
    }

    public ReportDto CreateReport()
    {
        _counter++;
        var messages = new List<string>();
        foreach (Message message in ReportsAppContext.Messages)
        {
            if (message.MessageStatus != MessageStatus.Answered) continue;
            messages.Add($"id = {message.Id}\n" +
                         $"text = {message.MessageText}\n" +
                         $"answer = {message.Answer}");
            message.MessageStatus = MessageStatus.Reported;
            ReportsAppContext.Update(message);
            ReportsAppContext.SaveChanges();
        }

        var report = new Report
        (new ReportInfo(DateTime.Now),
            new ReportMessageList(messages),
            _counter);

        ReportsAppContext.Reports.Add(report);
        ReportsAppContext.SaveChanges();

        return ReportMapper.Map(report);
    }
}