namespace Banks.Exceptions;

public class NotifyException : SystemException
{
    public NotifyException()
        : base($"Notify is nulll")
    {
    }
}