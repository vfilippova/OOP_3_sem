namespace Banks.Interfaces;

public abstract class InfoListener : IInfoListener
{
    protected string Information { get; private set; } = string.Empty;

    public void UpdateInfo(string information)
    {
        Information += information;
    }
}