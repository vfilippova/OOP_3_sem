namespace Isu.Extra.Exception;

public class InvalidOgnpGroupException : SystemException
{
    public InvalidOgnpGroupException(string ognpGroupName)
        : base($"Group {ognpGroupName} does not exist")
    {
    }
}