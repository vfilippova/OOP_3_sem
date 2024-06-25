using Backups;
using Backups.Services;


namespace Backups.Test2;

public class Program
{
    static void Main()
    {
        BackupService backupService = new BackupService();
        SingleStorage singleStorage = new SingleStorage();
        Backup backup = new Backup();
        Repository repository = backupService.CreateRepository(backup, "FileSystemRepository");
        BackupTask backupTask = backupService.CreateBackupTask(singleStorage, "Test", repository);
        File file1 = new File("Test1");
        Folder file2 = new Folder("Test2");
        BackupObject backupObject1 = backupService.CreateBackupObject(file1);
        BackupObject backupObject2 = backupService.CreateBackupObject(file2);
        backupService.AddBackupObjectToBackupTask(backupTask, backupObject1);
        backupService.AddBackupObjectToBackupTask(backupTask, backupObject2);
    }
}