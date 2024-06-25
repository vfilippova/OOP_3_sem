namespace Backups.Extra.JSON;

public class BOinSingleStorage
{
    public BOinSingleStorage(Guid singleStorageDataId, Guid backupObjectDataId)
    {
        BackupObjectDataId = backupObjectDataId;
        SingleStorageDataId = singleStorageDataId;
        Id = Guid.NewGuid();
    }

    public Guid SingleStorageDataId { get; set; }
    public Guid Id { get; set; }
    public Guid BackupObjectDataId { get; set; }
}