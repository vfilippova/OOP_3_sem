namespace Isu.Extra.Exception;

public class MaxStudentInOGNPException : SystemException
{
    public MaxStudentInOGNPException(string ognp)
        : base($"Max number of student in a group {ognp}")
    {
    }
}