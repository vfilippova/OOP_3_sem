using Reports.DAL.Stuff.Directors;
using Reports.Services;

namespace Reports.CLI.Commands;

public class NewDirectorCommand : ICommand
{
    public NewDirectorCommand(MultiService multiService)
    {
        MultiService = multiService;
    }

    public MultiService MultiService { get; }

    public void Execute()
    {
        Console.WriteLine("input login, password, name, info and role by enter");
        string login = Console.ReadLine(),
            password = Console.ReadLine(),
            name = Console.ReadLine(),
            info = Console.ReadLine();

        DirectorRole directorRole = Console.ReadLine() switch
        {
            "low" => DirectorRole.Low,
            "middle" => DirectorRole.Middle,
            "high" => DirectorRole.High,
            _ => DirectorRole.Low
        };

        MultiService.AddDirector(login, password, name, info, directorRole);
    }
}