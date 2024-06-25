namespace Backups.Extra.JSON;

public class BackupObjectData
{
    public BackupObjectData(string type, int version, string path)
    {
        Id = Guid.NewGuid();
        Type = type;
        Version = version;
        Path = path;
    }

    public Guid Id { get; set; }
    public string Type { get; set; }
    public int Version { get; set; }
    public string Path { get; set; }
}