namespace Backups;

public interface IRepositoryRead
{
    void AddFile(FileInfo file);
    void RemoveFile(FileInfo file);
    void AddRestorePoint(RestorePoint restorePoint);
}