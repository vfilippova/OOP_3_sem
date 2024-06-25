namespace Isu.Extra.Exception;

public class NegativeStudentInGroupOGNPException : SystemException
{
    public NegativeStudentInGroupOGNPException(int maxStudent)
        : base($"Negative number of student in group OGNP {maxStudent}")
    {
    }
}