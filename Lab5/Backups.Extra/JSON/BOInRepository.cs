namespace Backups.Extra.JSON;

public class BOInRepository
{
    public BOInRepository(Guid backupObjectId, Guid repositoryId)
    {
        BackupObjectId = backupObjectId;
        RepositoryId = repositoryId;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public Guid BackupObjectId { get; set; }
    public Guid RepositoryId { get; set; }
}