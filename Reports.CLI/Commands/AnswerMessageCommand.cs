using Reports.Services;

namespace Reports.CLI.Commands;

public class AnswerMessageCommand : ICommand
{
    public AnswerMessageCommand(MultiService multiService)
    {
        MultiService = multiService;
    }

    public MultiService MultiService { get; }
    public void Execute()
    {
        throw new NotImplementedException();
    }
}