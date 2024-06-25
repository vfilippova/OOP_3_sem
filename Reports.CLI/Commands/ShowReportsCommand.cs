using Reports.BLL.Dto;
using Reports.Services;

namespace Reports.CLI.Commands;

public class ShowReportsCommand : ICommand
{
    public ShowReportsCommand(MultiService multiService)
    {
        MultiService = multiService;
    }

    public MultiService MultiService { get; }

    public void Execute()
    {
        foreach (ReportDto reportDto in MultiService.GetReports())
        {
            Console.WriteLine($"{reportDto.ReportInfo.DateTime}");
            foreach (string message in reportDto.ReportMessageList.Messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}