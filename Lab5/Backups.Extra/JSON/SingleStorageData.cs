namespace Backups.Extra.JSON;

public class SingleStorageData
{
    public SingleStorageData()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}