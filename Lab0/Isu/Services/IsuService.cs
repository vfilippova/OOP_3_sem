using Isu.Entities;
using Isu.Exception;
using Isu.Models;

namespace Isu.Services;

public class IsuService : IIsuService
{
    private List<Group> _groups;
    private List<Student> _students = new List<Student>();
    private int _studentId;

    public IsuService()
    {
        _groups = new List<Group>();
        _studentId = 100000;
    }

    public Group AddGroup(GroupName name)
    {
        if (name == null)
        {
            throw new InvalidGroupException("Parameter must not be null");
        }

        var newGroup = new Group(name);
        _groups.Add(newGroup);
        return newGroup;
    }

    public Student AddStudent(Group group, string name)
    {
        if (group is null)
        {
            throw new System.Exception();
        }

        var newStudent = new Student(name, ++_studentId, group);
        _students.Add(newStudent);
        group.AddStudent(newStudent);
        return newStudent;
    }

    public Student GetStudent(int id)
    {
        return FindStudent(id) ?? throw new InvalidStudentException(id);
    }

    public Student? FindStudent(int id)
    {
        return _students.FirstOrDefault(student => student.Id == id);
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        return _students!.Where(student => student.Group.GroupName == groupName).ToList();
    }

    public IReadOnlyList<Student> FindStudents(CourseNumber courseNumber)
    {
        if (courseNumber is null)
        {
            throw new ("Group not correct");
        }

        return _students!.Where(student => student.Group.GroupName.CourseNumber == courseNumber).ToList();
    }

    public IReadOnlyList<Group> FindGroup(GroupName groupName)
    {
        return _groups.Where(group => group.GroupName == groupName).ToList();
    }

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        return _groups.Where(group => group.GroupName.CourseNumber == courseNumber).ToList();
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        Group oldGroup = student.Group;

        GetStudent(student.Id);
        newGroup.AddStudent(student);
        oldGroup.RemoveStudent(student);
        student.ChangeGroup(newGroup);
    }
}