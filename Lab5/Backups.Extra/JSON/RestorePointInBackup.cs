namespace Backups.Extra.JSON;

public class RestorePointInBackup
{
    public RestorePointInBackup(Guid restorePointId, Guid backupId)
    {
        Id = Guid.NewGuid();
        RestorePointId = restorePointId;
        BackupId = backupId;
    }

    public Guid Id { get; set; }
    public Guid RestorePointId { get; set; }
    public Guid BackupId { get; set; }
}