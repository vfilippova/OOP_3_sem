using Reports.Services;

namespace Reports.CLI.Commands;

public class CreateReportCommand : ICommand
{
    public CreateReportCommand(MultiService multiService)
    {
        MultiService = multiService;
    }

    public MultiService MultiService { get; }

    public void Execute()
    {
        MultiService.CreateReport();
    }
}