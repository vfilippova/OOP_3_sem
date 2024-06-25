using Backups;
using Backups.Services;
using Xunit;

namespace Backups.Test;

public class BackupServiceTest
{
    [Fact]
    public void Test()
    {
        // arrange
        BackupService backupService = new BackupService();
        int expected = 2;
        SplitStorage splitStorage = new SplitStorage();
        Backup backup = new Backup();
        Repository repository = backupService.CreateRepository(backup, "Rep");
        BackupTask backupTask = backupService.CreateBackupTask(splitStorage, "Task", repository);
        File file1 = new File("Test1");
        File file2 = new File("Test2");
        BackupObject backupObject1 = backupService.CreateBackupObject(file1);
        BackupObject backupObject2 = backupService.CreateBackupObject(file2);

        // act
        backupService.AddBackupObjectToBackupTask(backupTask, backupObject1);
        backupService.AddBackupObjectToBackupTask(backupTask, backupObject2);
        backupService.RunBackupTask(backupTask);
        backupService.RemoveBackupObjectToBackupTask(backupTask, backupObject1);
        backupService.RunBackupTask(backupTask);
        int actual = backup.GetRestorePointsCount();

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test2()
    {
        // arrange
        BackupService backupService = new BackupService();
        int expected = 2;
        SingleStorage singleStorage = new SingleStorage();
        Backup backup = new Backup();
        Repository repository = backupService.CreateRepository(backup, "Rep");
        BackupTask backupTask = backupService.CreateBackupTask(singleStorage, "Task", repository);
        File file1 = new File("Test1");
        File file2 = new File("Test2");
        BackupObject backupObject1 = backupService.CreateBackupObject(file1);
        BackupObject backupObject2 = backupService.CreateBackupObject(file2);

        // act
        backupService.AddBackupObjectToBackupTask(backupTask, backupObject1);
        backupService.AddBackupObjectToBackupTask(backupTask, backupObject2);
        backupService.RunBackupTask(backupTask);
        backupService.RemoveBackupObjectToBackupTask(backupTask, backupObject1);
        backupService.RunBackupTask(backupTask);
        int actual = backup.GetRestorePointsCount();

        // assert
        Assert.Equal(expected, actual);
    }
}