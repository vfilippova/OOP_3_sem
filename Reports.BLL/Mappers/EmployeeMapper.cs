using Reports.BLL.Dto;
using Reports.DAL.Stuff.Employees;

namespace Reports.BLL.Mappers;

public static class EmployeeMapper
{
    public static EmployeeDto Map(Employee employee)
    {
        return new EmployeeDto(employee.Name, employee.Info, employee.EmployeeRole, employee.Id);
    }
}