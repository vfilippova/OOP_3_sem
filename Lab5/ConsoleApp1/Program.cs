using Backups;
using Backups.Extra;

BackupExtraServices backupExtraServices = new BackupExtraServices(Mode.Count, false);
Backup backup = new Backup();
BackupObject backupObject = backupExtraServices.CreateBackupObject(new Backups.File("File.txt"));
Repository repository = backupExtraServices.CreateRepository(backup, "Rep", backupObject);
BackupTask backupTask = backupExtraServices.CreateBackupTask(new SingleStorage(), "BT", repository,LogMode.Console,backupObject);
backupExtraServices.RunBackupTask(backupTask);
backupExtraServices.SaveState();
BackupExtraServices backupExtraServices1 = new BackupExtraServices(Mode.Count, false);
backupExtraServices1.LoadState();
Console.ReadLine();