using Reports.DAL.Messages;
using Reports.Services;

namespace Reports.CLI.Commands;

public class NewMessageCommand : ICommand
{
    public NewMessageCommand(MultiService multiService)
    {
        MultiService = multiService;
    }

    public MultiService MultiService { get; }

    public void Execute()
    {
        Console.WriteLine("input messageText and message sender, by enter");
        string messageInfo = Console.ReadLine(),
            messageSender = Console.ReadLine();

        MultiService.AddMessage(messageInfo, messageSender, MessageStatus.Sent);
    }
}