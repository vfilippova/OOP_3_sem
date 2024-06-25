using Reports.DAL.Stuff.Employees;

namespace Reports.BLL.Dto;

public record EmployeeDto(string Name, string Info, EmployeeRole EmployeeRole, int Id);