namespace Reports.DAL.Stuff.Employees;

public class Employee
{
    public Employee(EmployeeAccount employeeAccount, string name, string info, EmployeeRole employeeRole, int id)
    {
        EmployeeAccount = employeeAccount;
        Name = name;
        Info = info;
        EmployeeRole = employeeRole;
        Id = id;
    }

    public Employee()
    {
    }

    public int Id { get; set; }
    public EmployeeAccount EmployeeAccount { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public EmployeeRole EmployeeRole { get; set; }
}