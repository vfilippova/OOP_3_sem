namespace Banks.Exceptions;

public class ConfigException : SystemException
{
    public ConfigException()
        : base($"Config is null")
    {
    }
}