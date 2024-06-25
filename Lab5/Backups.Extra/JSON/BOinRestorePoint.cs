namespace Backups.Extra.JSON;

public class BOinRestorePoint
{
    public BOinRestorePoint(Guid backupObjectId, Guid restorePointId)
    {
        BackupObjectId = backupObjectId;
        RestorePointId = restorePointId;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public Guid BackupObjectId { get; set; }
    public Guid RestorePointId { get; set; }
}