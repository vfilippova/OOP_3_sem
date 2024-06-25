namespace Backups.Extra.JSON;

public class BOinBackupTask
{
    public BOinBackupTask(Guid backupObjectId, Guid backupTaskId)
    {
        BackupObjectId = backupObjectId;
        BackupTaskId = backupTaskId;
        Id = Guid.NewGuid();
    }

    public Guid BackupTaskId { get; set; }
    public Guid Id { get; set; }
    public Guid BackupObjectId { get; set; }
}