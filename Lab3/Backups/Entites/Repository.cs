namespace Backups;

public class Repository
{
    private List<BackupObject> _backupObjects = new List<BackupObject>();
    private List<IStorageAlgorithm> _storages = new List<IStorageAlgorithm>();
    private Backup _backup = new Backup();

    public Repository(Backup backup, string name, params BackupObject[] backupObjects)
    {
        Name = name;
        _backup = backup;
        foreach (var obj in backupObjects)
        {
            _backupObjects.Add(obj);
        }
    }

    public string Name { get; set; }

    public void AddBackupObject(BackupObject obj)
    {
        _backupObjects.Add(obj);
    }

    public void AddIStorageAlgorithm(IStorageAlgorithm iStorageAlgorithm)
    {
        _storages.Add(iStorageAlgorithm);
    }

    public void AddRestorePoint(RestorePoint restorePoint)
    {
        _backup.AddRestorePoint(restorePoint);
    }

    public void LogConsole(bool isTime)
    {
        if (isTime)
        {
            Console.Write(DateTime.Now);
        }

        Console.WriteLine("Repository created");
    }

    public void LogFile(string file, bool isTime)
    {
        using (StreamWriter writer = new StreamWriter(System.IO.File.Open(file, FileMode.Append)))
        {
            if (isTime)
            {
                writer.Write(DateTime.Now);
            }

            writer.WriteLine("Repository createated");
        }
    }
}