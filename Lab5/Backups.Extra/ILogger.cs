namespace Backups.Extra;

public interface ILogger
{
    void Log(BackupEvent backupEvent);
}