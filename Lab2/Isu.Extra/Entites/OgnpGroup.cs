using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;

namespace Isu.Extra.Entites;

public class OgnpGroup
{
    private List<Student> _students = new List<Student>();
    public OgnpGroup(OgnpGroupName ognpGroupName, Flow flow)
    {
        OgnpGroupName = ognpGroupName;
        Flow = flow;
    }

    public OgnpGroupName OgnpGroupName { get; }
    public Flow Flow { get; }

    public StudentOgnpGroup AddStudentOgnpGroup(Student student)
    {
        _students.Add(student);
        return new StudentOgnpGroup(student, this);
    }

    public void RemoveStudent(Student student)
    {
        if (_students.Contains(student))
        {
            throw new InvalidStudentOgnpGroupException(student.Id);
        }
    }
}