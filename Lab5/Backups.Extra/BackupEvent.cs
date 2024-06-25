namespace Backups.Extra;

public enum BackupEvent
{
    CreateBackupTask,
    RunBackupTask,
    AddBackupObjectToBackupTask,
    RemoveBackupObjectToBackupTask,
    CreateRepository,
    CreateBackupObject,
}