namespace Backups;

public class File : IObject
{
    private string _fullName;
    private string _name;

    public File(string fullName)
    {
        _fullName = fullName;
        var splitted = fullName.Split('\\');
        _name = splitted[splitted.Length - 1];
    }

    public string GetFullPath()
    {
        return _fullName;
    }

    public string GetName()
    {
        return _name;
    }
}