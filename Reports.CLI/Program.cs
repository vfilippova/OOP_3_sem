using Reports.BLL.Dto;
using Reports.CLI.Handlers;
using Reports.Services;

namespace Reports.CLI;

using static Console;

class Program
{
    public static void Main()
    {
        var multiService = new MultiService("admin", "admin");

        WriteLine("authorizing...");
        WriteLine("chose worker(1) or boss(2) or admin(3)");
        string number = ReadLine();
        WriteLine("input login and password");
        string login = ReadLine();
        string password = ReadLine();

        if (multiService.IsAdmin(login, password))
        {
            while (true)
            {
                new AdminHandler(multiService).Handle();
            }
        }

        DirectorDto director = multiService.AuthorizeDirector(login, password);
        EmployeeDto employee = multiService.AuthorizeEmployee(login, password);

        if (director != null)
        {
            while (true)
            {
                new DirectorHandler(director, multiService).Handle();
            }
        }

        if (employee == null) return;
        while (true)
        {
            new EmployeeHandler(director, multiService).Handle();
        }
    }
}