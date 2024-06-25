using System.IO;
using System.Text.Json;
using Backups.Extra.JSON;
using Backups.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Backups.Extra;

public class BackupExtraServices
{
    private BackupService backupService = new BackupService();

    private Dictionary<BackupObject, BackupObjectData>
        _backupObjects = new Dictionary<BackupObject, BackupObjectData>();

    private Dictionary<BackupTask, BackupTaskData> _backupTasks = new Dictionary<BackupTask, BackupTaskData>();
    private Dictionary<Repository, RestorePoint> _restorePoints = new Dictionary<Repository, RestorePoint>();
    private Dictionary<Repository, Backup> _repository = new Dictionary<Repository, Backup>();
    private Dictionary<Repository, List<BackupObject>> _backupObjectsRepository = new Dictionary<Repository, List<BackupObject>>();
    private Dictionary<Repository, RepositoryData> _repositoryDatas = new Dictionary<Repository, RepositoryData>();
    private Dictionary<Backup, BackupData> _backupDatas = new Dictionary<Backup, BackupData>();
    private Dictionary<RestorePoint, RestorePointData> _restorePointDatas =
        new Dictionary<RestorePoint, RestorePointData>();
    private Dictionary<BackupTask, Repository> _repositories = new Dictionary<BackupTask, Repository>();
    private List<BOInRepository> _boInRepositories = new List<BOInRepository>();
    private List<BOinBackupTask> _boInBackupTasks = new List<BOinBackupTask>();
    private List<RestorePointInBackup> _restorePointInBackups = new List<RestorePointInBackup>();
    private List<BOinRestorePoint> _bOinRestorePoints = new List<BOinRestorePoint>();
    private int _maxRestorePoints;
    private int _maxDate;
    private Mode _mode;
    private LogMode _logMode;
    private bool _isTime;
    private string _file;

    public BackupExtraServices(Mode mode, bool isTime, string file = "", int n = -1, int maxDate = -1)
    {
        _mode = mode;
        _maxDate = maxDate;
        _maxRestorePoints = n;
        _isTime = isTime;
        _file = file;
    }

    public int GetRestorePointCount()
    {
        return _restorePointDatas.Count;
    }

    public BackupObject CreateBackupObject(IObject obj)
    {
        BackupObject backupObject = backupService.CreateBackupObject(obj);
        string type = obj is File ? "file" : "folder";
        BackupObjectData backupObjectData = new BackupObjectData(type, backupObject.GetVersion(), obj.GetFullPath());
        _backupObjects[backupObject] = backupObjectData;
        switch (_logMode)
        {
            case LogMode.Console:
                backupObject.LogConsole(_isTime);
                break;
            case LogMode.File:
                backupObject.LogFile(_file, _isTime);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return backupObject;
    }

    public BackupTask CreateBackupTask(IStorageAlgorithm storageAlgorithm, string name, Repository repository, LogMode logMode, params BackupObject[] objects)
    {
        _logMode = logMode;
        BackupTask backupTask = backupService.CreateBackupTask(storageAlgorithm, name, repository, objects);
        string storageAlgorithms = storageAlgorithm is SingleStorage ? "Single" : "Split";
        _backupTasks[backupTask] = new BackupTaskData(_repositoryDatas[repository].Id, storageAlgorithms, name);
        foreach (var backupObject in objects)
        {
            _boInBackupTasks.Add(new BOinBackupTask(_backupObjects[backupObject].Id, _backupTasks[backupTask].Id));
        }

        _repositories[backupTask] = repository;

        switch (_logMode)
        {
            case LogMode.Console:
                backupTask.LogConsole(_isTime);
                break;
            case LogMode.File:
                backupTask.LogFile(_file, _isTime);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return backupTask;
    }

    public void RunBackupTask(BackupTask backupTask, HybridMode hybridMode = HybridMode.And)
    {
        RestorePoint? restorePoint = backupTask.Run();

        if (restorePoint != null)
        {
            _restorePointDatas[restorePoint] =
                new RestorePointData(_backupTasks[backupTask].StorageAlgoritm, DateTime.Now);
            _restorePointInBackups.Add(new RestorePointInBackup(
                _restorePointDatas[restorePoint].Id,
                _backupDatas[_repository[_repositories[backupTask]]].Id));
            var storages = _boInBackupTasks.FindAll(x => x.BackupTaskId == _backupTasks[backupTask].Id);
            foreach (var storage in storages)
            {
                BOinRestorePoint boInRestorePoint =
                    new BOinRestorePoint(storage.BackupObjectId, _restorePointDatas[restorePoint].Id);
                _bOinRestorePoints.Add(boInRestorePoint);
            }

            switch (_mode)
            {
                case Mode.Count:
                    if (_restorePointDatas.Count > _maxRestorePoints)
                    {
                       var min = _restorePointDatas.MinBy(x => x.Value.DateTime);
                       _restorePointDatas.Remove(min.Key);
                    }

                    break;
                case Mode.Date:
                    foreach (var rp in _restorePointDatas)
                    {
                        if ((DateTime.Now - rp.Value.DateTime).TotalDays > _maxDate)
                        {
                            _restorePointDatas.Remove(rp.Key);
                        }
                    }

                    break;
                case Mode.Hybrid:
                    switch (hybridMode)
                    {
                        case HybridMode.And:
                            if (_restorePointDatas.Count > _maxRestorePoints)
                            {
                                var min = _restorePointDatas.MinBy(x => x.Value.DateTime);
                                if ((DateTime.Now - min.Value.DateTime).TotalDays > _maxDate)
                                {
                                    _restorePointDatas.Remove(min.Key);
                                }
                            }

                            break;
                        case HybridMode.Or:
                            foreach (var rp in _restorePointDatas)
                            {
                                if ((DateTime.Now - rp.Value.DateTime).TotalDays > _maxDate)
                                {
                                    _restorePointDatas.Remove(rp.Key);
                                }
                            }

                            if (_restorePointDatas.Count > _maxRestorePoints)
                            {
                                var min = _restorePointDatas.MinBy(x => x.Value.DateTime);
                                _restorePointDatas.Remove(min.Key);
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(hybridMode), hybridMode, null);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        switch (_logMode)
        {
            case LogMode.Console:
                restorePoint?.LogConsole(_isTime);
                break;
            case LogMode.File:
                restorePoint?.LogFile(_file, _isTime);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void SaveState()
    {
        WriteJSON<BackupObject, BackupObjectData>(_backupObjects, "BackupObjects.JSON");
        WriteJSON<Backup, BackupData>(_backupDatas, "Backups.JSON");
        WriteJSON<BackupTask, BackupTaskData>(_backupTasks, "BackupTask.JSON");
        WriteJSON<Repository, RepositoryData>(_repositoryDatas, "Repository.JSON");
        WriteJSON<RestorePoint, RestorePointData>(_restorePointDatas, "RestorePoint.JSON");

        string restorePointInBackupJSON = JsonSerializer.Serialize(_restorePointInBackups);
        System.IO.File.WriteAllText("RestorePointInBackup.JSON", restorePointInBackupJSON);

        string boInBackupTaskJSON = JsonSerializer.Serialize(_boInBackupTasks);
        System.IO.File.WriteAllText("BOInBackupTask.JSON", boInBackupTaskJSON);

        string boInRepositoryJSON = JsonSerializer.Serialize(_boInRepositories);
        System.IO.File.WriteAllText("BOInRepository.JSON", boInRepositoryJSON);

        string boInRestorePoint = JsonSerializer.Serialize(_bOinRestorePoints);
        System.IO.File.WriteAllText("boInRestorePoint.JSON", boInRestorePoint);
    }

    public RestorePoint Merge(params RestorePoint[] restorePoints)
    {
        throw new InvalidOperationException();
    }

    public Repository CreateRepository(Backup backup, string name, params BackupObject[] objects)
    {
        Repository newRepository = backupService.CreateRepository(backup, name, objects);
        _repository[newRepository] = backup;
        _backupObjectsRepository[newRepository] = objects.ToList();
        _backupDatas[backup] = new BackupData();
        _repositoryDatas[newRepository] = new RepositoryData(_backupDatas[backup].Id, newRepository.Name);
        foreach (var backupObject in objects)
        {
            _boInRepositories.Add(new BOInRepository(_backupObjects[backupObject].Id, _repositoryDatas[newRepository].Id));
        }

        switch (_logMode)
        {
            case LogMode.Console:
                newRepository.LogConsole(_isTime);
                break;
            case LogMode.File:
                newRepository.LogFile(_file, _isTime);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return newRepository;
    }

    public void LoadState()
    {
        string backupObjectsFile = "BackupObjects.JSON";
        string backupObjectsJSON = System.IO.File.ReadAllText(backupObjectsFile);
        List<BackupObjectData>? backupObjectDatas = JsonSerializer.Deserialize<List<BackupObjectData>>(backupObjectsJSON);
        if (backupObjectDatas != null)
        {
            foreach (var backupObjectData in backupObjectDatas)
            {
                BackupObject backupObject = new BackupObject(backupObjectData.Path == "file" ? new File(backupObjectData.Path) : new Folder(backupObjectData.Path));
                _backupObjects[backupObject] = backupObjectData;
            }
        }

        string backupsFile = "Backups.JSON";
        string backupsJSON = System.IO.File.ReadAllText(backupsFile);
        List<BackupData>? backupDatas = JsonSerializer.Deserialize<List<BackupData>>(backupsJSON);
        if (backupDatas != null)
        {
            foreach (var backupData in backupDatas)
            {
                Backup backup = new Backup();
                _backupDatas[backup] = backupData;
            }
        }

        string repositoryFile = "Repository.JSON";
        string repositoryJSON = System.IO.File.ReadAllText(repositoryFile);
        List<RepositoryData>? repositoryDatas = JsonSerializer.Deserialize<List<RepositoryData>>(repositoryJSON);
        if (repositoryDatas != null)
        {
            foreach (var repositoryData in repositoryDatas)
            {
                Backup backup = _backupDatas.First(x => x.Value.Id == repositoryData.BackupId).Key;
                Repository repository = new Repository(backup, repositoryData.Name);
                _repositoryDatas[repository] = repositoryData;
            }
        }

        string backupTaskFile = "BackupTask.JSON";
        string backupTaskJSON = System.IO.File.ReadAllText(backupTaskFile);
        List<BackupTaskData>? backupTaskDatas = JsonSerializer.Deserialize<List<BackupTaskData>>(backupTaskJSON);
        if (backupTaskDatas != null)
        {
            foreach (var backupTaskData in backupTaskDatas)
            {
                IStorageAlgorithm storageAlgorithm = backupTaskData.StorageAlgoritm == "Single" ? new SingleStorage() : new SplitStorage();
                Repository repository = _repositoryDatas.First(x => x.Value.Id == backupTaskData.RepositoryId).Key;
                BackupTask backupTask = new BackupTask(storageAlgorithm, backupTaskData.Name, repository);
                _backupTasks[backupTask] = backupTaskData;
            }
        }

        string restorePointFile = "restorePoint.JSON";
        string restorePointJSON = System.IO.File.ReadAllText(restorePointFile);
        List<RestorePointData>? restorePointDatas = JsonSerializer.Deserialize<List<RestorePointData>>(restorePointJSON);
        if (restorePointDatas != null)
        {
            foreach (var restorePointData in restorePointDatas)
            {
                IStorageAlgorithm storageAlgorithm = restorePointData.StorageAlgoritm == "Single" ? new SingleStorage() : new SplitStorage();
                RestorePoint restorePoint = new RestorePoint(storageAlgorithm, restorePointData.DateTime);
                _restorePointDatas[restorePoint] = restorePointData;
            }
        }

        string boInBackupTaskFile = "boInBackupTask.JSON";
        string boInBackupTaskJSON = System.IO.File.ReadAllText(boInBackupTaskFile);
        List<BOinBackupTask>? boInBackupTasks = JsonSerializer.Deserialize<List<BOinBackupTask>>(boInBackupTaskJSON);
        if (boInBackupTasks != null)
        {
            foreach (var boInBackupTaskData in boInBackupTasks)
            {
                BOinBackupTask boInBackupTask = new BOinBackupTask(boInBackupTaskData.BackupObjectId, boInBackupTaskData.BackupTaskId);
                _boInBackupTasks.Add(boInBackupTask);
            }
        }

        string boInRepositoryFile = "boInRepository.JSON";
        string boInRepositoryJSON = System.IO.File.ReadAllText(boInRepositoryFile);
        List<BOInRepository>? boInRepositories = JsonSerializer.Deserialize<List<BOInRepository>>(boInRepositoryJSON);
        if (boInRepositories != null)
        {
            foreach (var boInRepositoryData in boInRepositories)
            {
                BOInRepository boInRepository = new BOInRepository(boInRepositoryData.BackupObjectId, boInRepositoryData.RepositoryId);
                _boInRepositories.Add(boInRepository);
            }
        }
    }

    public void Restore(RestorePoint restorePoint, RestoreMode restoreMode, Repository repository)
    {
        switch (restoreMode)
        {
            case RestoreMode.Original:
                var bo = _bOinRestorePoints.FindAll(x => x.RestorePointId == _restorePointDatas[restorePoint].Id);

                // repository = _repository.First(x => x.Value ==
                //                                                 _backupDatas.First(x => x.Value.Id ==
                //                                                     _restorePointInBackups.Find(x => x.RestorePointId ==
                //                                                         _restorePointDatas[restorePoint].Id).BackupId));BackupId
                foreach (var b in bo)
                {
                    repository.AddBackupObject(_backupObjects.First(x => x.Value.Id == b.BackupObjectId).Key);
                }

                break;
            case RestoreMode.Different:
                var bo1 = _bOinRestorePoints.FindAll(x => x.RestorePointId == _restorePointDatas[restorePoint].Id);
                foreach (var b in bo1)
                {
                    repository.AddBackupObject(_backupObjects.First(x => x.Value.Id == b.BackupObjectId).Key);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(restoreMode), restoreMode, null);
        }
    }

    private void WriteJSON<T1, T2>(Dictionary<T1, T2> objects, string name)
        where T1 : notnull
    {
        List<T2> backupObjectDatas = new List<T2>();
        foreach (var backupObject in objects)
        {
            backupObjectDatas.Add(backupObject.Value);
        }

        string backupObjectsJSON = JsonSerializer.Serialize(backupObjectDatas);
        System.IO.File.WriteAllText(name, backupObjectsJSON);
    }
}