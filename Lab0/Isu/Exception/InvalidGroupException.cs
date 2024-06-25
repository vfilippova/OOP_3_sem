using Isu.Models;

namespace Isu.Exception;

public class InvalidGroupException : System.Exception
{
    public InvalidGroupException(string groupName)
        : base($"Group {groupName} does not exist")
    {
    }
}