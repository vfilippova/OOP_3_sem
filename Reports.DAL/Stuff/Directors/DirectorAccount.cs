namespace Reports.DAL.Stuff.Directors;

public class DirectorAccount
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public DirectorAccount(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public DirectorAccount()
    {
    }
}