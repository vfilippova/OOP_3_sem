using Reports.BLL.Dto;
using Reports.BLL.Exceptions;
using Reports.BLL.Mappers;
using Reports.DAL.Contexts;
using Reports.DAL.Stuff.Employees;
using Reports.Services.Services;

namespace Reports.Services.Entities;

public class EmployeeService : IEmployeeService
{
    private static int _counter = 0;

    public EmployeeService(ReportsAppContext reportsAppContext)
    {
        ReportsAppContext = reportsAppContext;
    }

    public ReportsAppContext ReportsAppContext { get; }

    public List<EmployeeDto> GetEmployees()
    {
        return ReportsAppContext.Employees.Select(x => EmployeeMapper.Map(x)).ToList();
    }

    public EmployeeDto AddEmployee(
        string login,
        string password,
        string name,
        string info,
        EmployeeRole employeeRole)
    {
        _counter++;
        var employee = new Employee(new EmployeeAccount(login, password), name, info, employeeRole, _counter);

        ReportsAppContext.Employees.Add(employee);
        ReportsAppContext.SaveChanges();

        return EmployeeMapper.Map(employee);
    }

    public EmployeeDto GetEmployee(int id)
    {
        return GetEmployees().First(x => x.Id == id);
    }

    public EmployeeDto FindEmployee(int id)
    {
        return GetEmployees().FirstOrDefault(x => x.Id == id) ?? throw new ReportsException();
    }

    public EmployeeDto GetEmployee(string login)
    {
        return EmployeeMapper.Map(ReportsAppContext.Employees.First(x => x.EmployeeAccount.Login.Equals(login)));
    }

    public EmployeeDto FindEmployee(string login)
    {
        return EmployeeMapper.Map(ReportsAppContext.Employees.FirstOrDefault(x => x.EmployeeAccount.Login.Equals(login)) ?? throw new ReportsException());
    }

    public EmployeeDto AuthorizeEmployee(string login, string password)
    {
        Employee employee = ReportsAppContext.Employees.ToList().Find(x => x.EmployeeAccount.Login == login);

        if (employee == null)
        {
            return null;
        }

        return employee.EmployeeAccount.Password != password ? null : EmployeeMapper.Map(employee);
    }
}