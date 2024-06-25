using Reports.CLI.Commands;
using Reports.Services;

namespace Reports.CLI.Handlers;

public class AdminHandler : IHandler
{
    public AdminHandler(MultiService multiService)
    {
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
                new NewDirectorCommand(MultiService).Execute();
                break;
            case "2":
                new NewEmployeeCommand(MultiService).Execute();
                break;
            case "3":
                new NewMessageCommand(MultiService).Execute();
                break;
        }
    }
}