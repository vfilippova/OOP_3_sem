namespace Reports.DAL.Stuff.Employees;

public class EmployeeAccount
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public EmployeeAccount(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public EmployeeAccount()
    {
    }
}