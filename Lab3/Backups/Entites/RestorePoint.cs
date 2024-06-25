namespace Backups;

public class RestorePoint
{
    private IStorageAlgorithm _storageAlgorithm;
    private DateTime _dateTime;
    private List<SplitStorage> _splitStorages = new List<SplitStorage>();

    public RestorePoint(IStorageAlgorithm storageAlgorithm, List<SplitStorage> splitStorages, DateTime dateTime)
        : this(storageAlgorithm, dateTime)
    {
        _splitStorages = splitStorages;
    }

    public RestorePoint(IStorageAlgorithm storageAlgorithm, DateTime dateTime)
    {
        _storageAlgorithm = storageAlgorithm;
        _dateTime = dateTime;
    }

    public void LogConsole(bool isTime)
    {
        if (isTime)
        {
            Console.Write(DateTime.Now);
        }

        Console.WriteLine("RestorePoint created");
    }

    public void LogFile(string file, bool isTime)
    {
        using (StreamWriter writer = new StreamWriter(System.IO.File.Open(file, FileMode.Append)))
        {
            if (isTime)
            {
                writer.Write(DateTime.Now);
            }

            writer.WriteLine("RestorePoint createated");
        }
    }
}