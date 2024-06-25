namespace Banks.Exceptions;

public class ClientBuilderException : SystemException
{
    public ClientBuilderException()
        : base($"ClientBuilder is null")
    {
    }
}