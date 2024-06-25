namespace Isu.Extra.Exception;

public class InvalidStudentOgnpGroupException : SystemException
{
    public InvalidStudentOgnpGroupException(int id)
        : base($"Student {id} does not exist")
    {
    }
}