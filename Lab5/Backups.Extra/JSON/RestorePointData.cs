namespace Backups.Extra.JSON;

public class RestorePointData
{
    public RestorePointData(string storageAlgoritm, DateTime dateTime)
    {
        Id = Guid.NewGuid();
        StorageAlgoritm = storageAlgoritm;
        DateTime = dateTime;
    }

    public Guid Id { get; set; }
    public string StorageAlgoritm { get; set; }
    public DateTime DateTime { get; set; }
}