namespace Banks.Exceptions;

public class InvalidCommand : SystemException
{
    public InvalidCommand()
        : base($"Команда не распознана")
    {
    }
}