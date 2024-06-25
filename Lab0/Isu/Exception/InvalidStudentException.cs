namespace Isu.Exception;

public class InvalidStudentException : SystemException
{
    public InvalidStudentException(int id)
        : base($"Student {id} does not exist")
    {
    }
}