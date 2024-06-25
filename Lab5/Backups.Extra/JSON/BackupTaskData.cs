namespace Backups.Extra.JSON;

public class BackupTaskData
{
    public BackupTaskData(Guid repositoryId, string storageAlgoritm, string name)
    {
        StorageAlgoritm = storageAlgoritm;
        Name = name;
        Id = Guid.NewGuid();
        RepositoryId = repositoryId;
    }

    public Guid Id { get; set; }
    public string StorageAlgoritm { get; set; }
    public string Name { get; set; }
    public Guid RepositoryId { get; set; }
}