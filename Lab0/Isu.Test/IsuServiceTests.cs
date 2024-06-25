using Isu.Entities;
using Isu.Exception;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Test;

public class IsuServiceTests
{
    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        var isu = new IsuService();
        Group group = isu.AddGroup(new GroupName("H3234"));
        Student student = isu.AddStudent(group, "Victoria Filippova");
        Assert.True(student.Group.GroupName == group.GroupName);
        Assert.Equal(group, student.Group);
        Assert.Equal(student.Group, group);
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        var isu = new IsuService();
        Group group = isu.AddGroup(new GroupName("H3323"));
        for (int i = 0; i <= Group.MaxStudent; ++i)
        {
            isu.AddStudent(group, "Victor Ladygin");
        }

        Assert.Throws<MaxStudentInGroupException>(() =>
            isu.AddStudent(group, "Victor Ladygin"));
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        var isu = new IsuService();
        Assert.Throws<InvalidGroupException>(() => isu.AddGroup(new GroupName("7dtrt7ofyu3345")));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        var isu = new IsuService();
        Group group = isu.AddGroup(new GroupName("N3334"));
        Group oldGroup = isu.AddGroup(new GroupName("N3433"));
        Student student = isu.AddStudent(oldGroup, "Victoria Filippova");
        isu.ChangeStudentGroup(student, group);
        Assert.Equal(group, student.Group);
    }
}