namespace Backups;

public class Folder : IObject
{
    private string _path;
    private string _name;

    public Folder(string path)
    {
        _path = path;
        var splitted = path.Split('\\');
        _name = splitted[splitted.Length - 1];
    }

    public string GetFullPath()
    {
        return _path;
    }

    public string GetName()
    {
        return _name;
    }
}