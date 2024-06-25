using Isu.Entities;

namespace Isu.Extra.Entites;

public class StudentOgnpGroup
{
    public StudentOgnpGroup(Student student, OgnpGroup ognpGroup)
    {
        Student = student;
        OgnpGroup = ognpGroup;
    }

    public Student Student { get; set; }
    public OgnpGroup OgnpGroup { get; set; }
}