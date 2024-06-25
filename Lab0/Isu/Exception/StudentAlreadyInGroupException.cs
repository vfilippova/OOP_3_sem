namespace Isu.Exception;

public class StudentAlreadyInGroupException : SystemException
{
    public StudentAlreadyInGroupException(string groupName)
        : base($"The student is already in the group {groupName}")
    {
    }
}