namespace Backups;

public class BackupTask
{
    private List<BackupObject> _backupObjects = new List<BackupObject>();
    private List<RestorePoint> _restorePoints = new List<RestorePoint>();
    private Repository _repository;
    private string _name;
    private IStorageAlgorithm _storageAlgorithm;
    private List<SplitStorage> _splitStorage = new List<SplitStorage>();

    public BackupTask(IStorageAlgorithm storageAlgorithm, string name, Repository repository, params BackupObject[] objects)
    {
        _repository = repository;
        _name = name;
        _storageAlgorithm = storageAlgorithm;
        foreach (var obj in objects)
        {
            _backupObjects.Add(obj);
        }
    }

    public void AddBackupObject(BackupObject backupObject)
    {
        _backupObjects.Add(backupObject);
    }

    public void RemoveBackupObject(BackupObject backupObject)
    {
        _backupObjects.Remove(backupObject);
    }

    public RestorePoint? Run()
    {
        RestorePoint? restorePoint;
        if (_storageAlgorithm is SingleStorage singleStorage)
        {
            singleStorage.CreateStorage(_backupObjects);
            restorePoint = new RestorePoint(singleStorage, DateTime.Now);
            _repository.AddRestorePoint(restorePoint);
            return restorePoint;
        }
        else if (_storageAlgorithm is SplitStorage splitStorage)
        {
            foreach (var backupObject in _backupObjects)
            {
                SplitStorage storage = new SplitStorage(backupObject);
                _splitStorage.Add(storage);
            }

            restorePoint = new RestorePoint(splitStorage, _splitStorage, DateTime.Now);

            _repository.AddRestorePoint(restorePoint);
            return restorePoint;
        }

    // List<Storage> storages = new List<Storage>();
    //     foreach (var backupObject in _backupObjects)
    //     {
    //         Storage newStorage = new Storage(backupObject);
    //         storages.Add(newStorage);
    //         _repository.AddStorage(newStorage);
    //         if (backupObject.GetObject() is File file)
    //         {
    //             // todo
    //             System.IO.File.Copy(file.GetFullPath(), $"{file.GetName()}({backupObject.NextVersion()})");
    //         }
    //         else if (backupObject.GetObject() is Folder folder)
    //         {
    //             CopyDir.Copy(folder.GetFullPath(), $"{folder.GetName()}({backupObject.NextVersion()})");
    //         }
    //     }
        return null;
    }

    public void LogConsole(bool isTime)
    {
        if (isTime)
        {
            Console.Write(DateTime.Now);
        }

        Console.WriteLine("BackupTask created");
    }

    public void LogFile(string file, bool isTime)
    {
        using (StreamWriter writer = new StreamWriter(System.IO.File.Open(file, FileMode.Append)))
        {
            if (isTime)
            {
                writer.Write(DateTime.Now);
            }

            writer.WriteLine("BackupTask createated");
        }
    }
}