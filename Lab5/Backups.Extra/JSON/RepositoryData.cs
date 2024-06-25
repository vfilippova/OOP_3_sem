namespace Backups.Extra.JSON;

public class RepositoryData
{
    public RepositoryData(Guid backupId, string name)
    {
        Id = Guid.NewGuid();
        BackupId = backupId;
        Name = name;
    }

    public Guid Id { get; set; }
    public Guid BackupId { get; set; }
    public string Name { get; set; }
}