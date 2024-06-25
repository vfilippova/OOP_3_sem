using Reports.Services;

namespace Reports.CLI.Commands;

public interface ICommand
{
    MultiService MultiService { get; }
    void Execute();
}