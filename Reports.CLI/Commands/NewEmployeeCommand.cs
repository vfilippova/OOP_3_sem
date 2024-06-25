using Reports.DAL.Stuff.Employees;
using Reports.Services;

namespace Reports.CLI.Commands;

public class NewEmployeeCommand : ICommand
{
    public NewEmployeeCommand(MultiService multiService)
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

        EmployeeRole employeeRole = Console.ReadLine() switch
        {
            "junior" => EmployeeRole.Junior,
            "middle" => EmployeeRole.Middle,
            "senior" => EmployeeRole.Senior,
            _ => EmployeeRole.Junior
        };

        MultiService.AddEmployee(login, password, name, info, employeeRole);
    }
}