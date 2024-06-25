using Reports.BLL.Dto;
using Reports.DAL.Messages;
using Reports.Services;

namespace Reports.CLI.Commands;

public class ShowMessagesCommand : ICommand
{
    public ShowMessagesCommand(MultiService multiService)
    {
        MultiService = multiService;
    }

    public MultiService MultiService { get; }

    public void Execute()
    {
        foreach (MessageDto message in MultiService.GetMessages())
        {
            Console.WriteLine($"message date = {message.MessageText}\n" +
                              $"message text = {message.MessageText}");
        }
    }
}