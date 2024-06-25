using Isu.Entities;

namespace Isu.Extra.Entites;

public class Lesson
{
    public Lesson(string name, DateTime startLesson, DateTime endLesson, ClassRoom classRoom, Teacher teacher, Group group)
    {
        Name = name;
        StartLesson = startLesson;
        EndLesson = endLesson;
        ClassRoom = classRoom;
        Teacher = teacher;
        Group = group;
    }

    public string Name { get; set; }
    public DateTime StartLesson { get; set; }
    public DateTime EndLesson { get; set; }
    public ClassRoom ClassRoom { get; set; }
    public Teacher Teacher { get; set; }
    public Group Group { get; set; }
}