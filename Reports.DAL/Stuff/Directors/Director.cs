namespace Reports.DAL.Stuff.Directors;

public class Director
{
    public Director(DirectorAccount directorAccount, string name, string info, DirectorRole directorRole, int id)
    {
        DirectorAccount = directorAccount;
        Name = name;
        Info = info;
        DirectorRole = directorRole;
        Id = id;
    }

    public Director()
    {
    }

    public int Id { get; set; }
    public DirectorAccount DirectorAccount { get; set; }
    public string Name { get; set; }
    public string Info { get; set; }
    public DirectorRole DirectorRole { get; set; }
}