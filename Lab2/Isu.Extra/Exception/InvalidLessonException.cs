namespace Isu.Extra.Exception;

public class InvalidLessonException : SystemException
{
    public InvalidLessonException(string lesson)
        : base($"Lesson {lesson} does not exist")
    {
    }
}