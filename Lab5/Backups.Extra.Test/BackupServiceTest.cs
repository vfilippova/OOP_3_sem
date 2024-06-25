using Xunit;

namespace Backups.Extra.Test;

public class BackupServiceTest
{
    [Fact(Skip = "doesn't work in gh")]
    public void Test1()
    {
        BackupExtraServices backupExtraServices = new BackupExtraServices(Mode.Count, false, "Log.txt");
        Backup backup = new Backup();
        BackupObject backupObject = backupExtraServices.CreateBackupObject(new Backups.File("File.txt"));
        BackupObject backupObject1 = backupExtraServices.CreateBackupObject(new Backups.File("File1.txt"));
        BackupObject backupObject2 = backupExtraServices.CreateBackupObject(new Backups.Folder("Folder"));
        Repository repository = backupExtraServices.CreateRepository(backup, "Rep", backupObject, backupObject1, backupObject2);
        BackupTask backupTask = backupExtraServices.CreateBackupTask(new SingleStorage(), "BT", repository, LogMode.File, backupObject, backupObject1, backupObject2);
        backupExtraServices.RunBackupTask(backupTask);
        backupExtraServices.SaveState();
        BackupExtraServices backupExtraServices1 = new BackupExtraServices(Mode.Count, false);
        backupExtraServices1.LoadState();
    }

    [Fact(Skip = "doesn't work in gh")]
    public void Test2()
    {
        // arrange
        BackupExtraServices backupExtraServices = new BackupExtraServices(Mode.Count, false, "Log.txt", 2);
        Backup backup = new Backup();
        BackupObject backupObject = backupExtraServices.CreateBackupObject(new Backups.File("File.txt"));
        BackupObject backupObject1 = backupExtraServices.CreateBackupObject(new Backups.File("File1.txt"));
        BackupObject backupObject2 = backupExtraServices.CreateBackupObject(new Backups.Folder("Folder"));
        Repository repository = backupExtraServices.CreateRepository(backup, "Rep", backupObject, backupObject1, backupObject2);
        BackupTask backupTask = backupExtraServices.CreateBackupTask(new SingleStorage(), "BT", repository, LogMode.File, backupObject, backupObject1, backupObject2);

        // act
        backupExtraServices.RunBackupTask(backupTask);
        backupExtraServices.RunBackupTask(backupTask);
        backupExtraServices.RunBackupTask(backupTask);

        // assert
        Assert.Equal(2, backupExtraServices.GetRestorePointCount());
    }

    [Fact(Skip = "doesn't work in gh")]
    public void Test3()
    {
        // arrange
        BackupExtraServices backupExtraServices = new BackupExtraServices(Mode.Date, false, "Log.txt", maxDate: 5);
        Backup backup = new Backup();
        BackupObject backupObject = backupExtraServices.CreateBackupObject(new Backups.File("File.txt"));
        BackupObject backupObject1 = backupExtraServices.CreateBackupObject(new Backups.File("File1.txt"));
        BackupObject backupObject2 = backupExtraServices.CreateBackupObject(new Backups.Folder("Folder"));
        Repository repository =
            backupExtraServices.CreateRepository(backup, "Rep", backupObject, backupObject1, backupObject2);
        BackupTask backupTask = backupExtraServices.CreateBackupTask(new SingleStorage(), "BT", repository, LogMode.File, backupObject, backupObject1, backupObject2);

        // act
        backupExtraServices.RunBackupTask(backupTask);

        // assert
        Assert.Equal(1, backupExtraServices.GetRestorePointCount());
    }
}