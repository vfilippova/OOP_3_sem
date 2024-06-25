using Reports.BLL.Dto;
using Reports.CLI.Commands;
using Reports.Services;

namespace Reports.CLI.Handlers;

public class EmployeeHandler : IHandler
{
    private readonly DirectorDto _directorDto;

    public EmployeeHandler(DirectorDto directorDto, MultiService multiService)
    {
        _directorDto = directorDto;
        MultiService = multiService;
    }

    public MultiService MultiService { get; }

    public void Handle()
    {
        Console.WriteLine("input command");
        string cmd = Console.ReadLine();
        switch (cmd)
        {
            case "1":
                new ShowMessagesCommand(MultiService).Execute();
                break;
            case "2":
                new AnswerMessageCommand(MultiService).Execute();
                break;
        }
    }
}