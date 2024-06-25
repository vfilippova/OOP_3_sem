namespace Backups;

public class Backup
{
    private List<RestorePoint?> _restorePoints = new List<RestorePoint?>();

    public void AddRestorePoint(RestorePoint? restorePoint)
    {
        _restorePoints.Add(restorePoint);
    }

    public int GetRestorePointsCount()
    {
        return _restorePoints.Count;
    }
}