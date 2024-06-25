namespace Backups.Services;

public class BackupService
{
    private List<Repository> _repositories = new List<Repository>();
    private List<BackupTask> _backupTasks = new List<BackupTask>();

    public Repository CreateRepository(Backup backup, string name, params BackupObject[] objects)
    {
        Repository newRepository = new Repository(backup, name, objects);
        _repositories.Add(newRepository);
        return newRepository;
    }

    public BackupTask CreateBackupTask(IStorageAlgorithm storageAlgorithm, string name, Repository repository, params BackupObject[] objects)
    {
        BackupTask newBackupTask = new BackupTask(storageAlgorithm, name, repository, objects);
        _backupTasks.Add(newBackupTask);
        return newBackupTask;
    }

    public void AddBackupObjectToBackupTask(BackupTask backupTask, BackupObject backupObject)
    {
        backupTask.AddBackupObject(backupObject);
    }

    public void RemoveBackupObjectToBackupTask(BackupTask backupTask, BackupObject backupObject)
    {
        backupTask.RemoveBackupObject(backupObject);
    }

    public RestorePoint? RunBackupTask(BackupTask backupTask)
    {
        RestorePoint? restorePoint = backupTask.Run();
        return restorePoint;
    }

    public BackupObject CreateBackupObject(IObject obj)
    {
        BackupObject backupObject = new BackupObject(obj);
        return backupObject;
    }
}