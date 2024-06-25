namespace Backups.Extra.JSON;

public class BackupData
{
    public BackupData()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}