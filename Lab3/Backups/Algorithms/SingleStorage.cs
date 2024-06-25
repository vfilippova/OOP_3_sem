namespace Backups;

public class SingleStorage : IStorageAlgorithm
{
    private List<BackupObject> _backupObjects = new List<BackupObject>();

    public List<BackupObject> GetBackupObjects()
    {
        return _backupObjects;
    }

    public void CreateStorage(List<BackupObject> backupObjects)
    {
        _backupObjects = backupObjects;
    }
}