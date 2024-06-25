namespace Backups.Extra.JSON;

public class SplitStorageData
{
    public SplitStorageData(Guid backupObjectId)
    {
        BackupObjectId = backupObjectId;
        Id = Guid.NewGuid();
    }

    public Guid BackupObjectId { get; set; }
    public Guid Id { get; set; }
}