using Reports.BLL.Dto;
using Reports.BLL.Exceptions;
using Reports.BLL.Mappers;
using Reports.DAL.Contexts;
using Reports.DAL.Stuff.Employees;

namespace Reports.Services.Services;

public interface IEmployeeService
{
    public ReportsAppContext ReportsAppContext { get; }

    List<EmployeeDto> GetEmployees();

    public EmployeeDto AddEmployee(string login, string password, string name, string info, EmployeeRole employeeRole);

    public EmployeeDto GetEmployee(int id);

    public EmployeeDto FindEmployee(int id);

    public EmployeeDto GetEmployee(string login);

    public EmployeeDto FindEmployee(string login);

    public EmployeeDto AuthorizeEmployee(string login, string password);
}