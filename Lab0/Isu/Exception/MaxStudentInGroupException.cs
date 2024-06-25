using Isu.Models;
namespace Isu.Exception;

public class MaxStudentInGroupException : SystemException
{
    public MaxStudentInGroupException(string groupName)
        : base($"Max namber of student in a group {groupName}")
    {
    }
}