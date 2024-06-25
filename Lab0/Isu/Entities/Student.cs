using Isu.Exception;
using Isu.Models;
namespace Isu.Entities;

public class Student
{
    public Student(string name, int id, Group group)
    {
        if (name == null)
        {
            throw new ArgumentNullException();
        }

        Name = name;
        Id = id;
        Group = group;
    }

    public string Name { get; set; }
    public int Id { get; set; }
    public Group Group { get; set; }

    public void ChangeGroup(Group group)
    {
        Group = group;
    }
}