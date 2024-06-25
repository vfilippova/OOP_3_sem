using Reports.Services;

namespace Reports.CLI.Handlers;

public interface IHandler
{
    MultiService MultiService { get; }

    void Handle();
}