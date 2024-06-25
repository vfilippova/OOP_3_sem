namespace Backups.Extra.JSON;

public class SplitStorageInRestorePoint
{
    public SplitStorageInRestorePoint(Guid splitStorageId, Guid restorePointId)
    {
        SplitStorageId = splitStorageId;
        RestorePointId = restorePointId;
        Id = Guid.NewGuid();
    }

    public Guid SplitStorageId { get; set; }
    public Guid RestorePointId { get; set; }
    public Guid Id { get; set; }
}