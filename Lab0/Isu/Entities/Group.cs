using System.Diagnostics;
using Isu.Exception;
using Isu.Models;

namespace Isu.Entities;

public class Group
{
    public const int MaxStudent = 15;
    private List<Student> _students = new List<Student>();

    public Group(GroupName groupName)
    {
        GroupName = groupName;
    }

    public GroupName GroupName { get; }
    public void AddStudent(Student student)
    {
        if (_students.Count > MaxStudent)
        {
            throw new MaxStudentInGroupException(student.Group.GroupName.Name);
        }

        if (_students.Contains(student))
        {
            throw new StudentAlreadyInGroupException(student.Name);
        }

        _students.Add(student);
    }

    public IReadOnlyCollection<Student> Student() => _students;

    public void RemoveStudent(Student student)
    {
        _students.Remove(student);
    }
}