namespace Backups;

public class SplitStorage : IStorageAlgorithm
{
    private BackupObject? _backupObject;

    public SplitStorage()
    {
    }

    public SplitStorage(BackupObject backupObject)
    {
        _backupObject = backupObject;
    }
}