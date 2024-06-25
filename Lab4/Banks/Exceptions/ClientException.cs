namespace Banks.Exceptions;

public class ClientException : SystemException
{
    public ClientException()
        : base($"Client is null")
    {
    }
}