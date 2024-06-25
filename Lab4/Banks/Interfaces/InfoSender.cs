namespace Banks.Interfaces;

public abstract class InfoSender
{
    protected List<InfoListener> Listeners { get; } = new List<InfoListener>();

    public void Subscribe(InfoListener listener)
    {
        if (Listeners.Contains(listener))
        {
            throw new Exception($"{listener} уже есть в списке");
        }

        Listeners.Add(listener);
    }

    public void Unsubscribe(InfoListener listener)
    {
        Listeners.Remove(listener);
    }

    public void Notify(string info)
    {
        foreach (InfoListener listener in Listeners)
        {
            listener.UpdateInfo(info);
        }
    }
}