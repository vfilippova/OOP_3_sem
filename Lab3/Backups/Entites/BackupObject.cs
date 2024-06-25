namespace Backups;

public class BackupObject
{
    private IObject _object;
    private int _version = 0;

    public BackupObject(IObject obj)
    {
        _object = obj;
    }

    public int NextVersion()
    {
        return ++_version;
    }

    public int GetVersion()
    {
        return _version;
    }

    public IObject GetObject()
    {
        return _object;
    }

    public void LogConsole(bool isTime)
    {
        if (isTime)
        {
            Console.Write(DateTime.Now);
        }

        Console.WriteLine("BackupObject created");
    }

    public void LogFile(string file, bool isTime)
    {
        using (StreamWriter writer = new StreamWriter(System.IO.File.Open(file, FileMode.Append)))
        {
            if (isTime)
            {
                writer.Write(DateTime.Now);
            }

            writer.WriteLine("BackupObject createated");
        }
    }
}