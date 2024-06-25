using Reports.BLL.Dto;
using Reports.DAL.Stuff.Employees;
using Reports.Services;

namespace Reports.CLI.Commands;

public class ShowEmployeesCommand : ICommand
{
    public ShowEmployeesCommand(MultiService multiService)
    {
        MultiService = multiService;
    }

    public MultiService MultiService { get; }

    public void Execute()
    {
        foreach (EmployeeDto employee in MultiService.GetEmployees())
        {
            Console.WriteLine($"employee name {employee.Name}\n" +
                              $"employee info {employee.Info}" +
                              $"employee id {employee.Id}");
        }
    }
}