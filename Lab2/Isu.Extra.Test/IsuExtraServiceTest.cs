using Isu.Entities;
using Isu.Extra.Entites;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Extra.Services;
using Isu.Models;
using Xunit;

namespace Isu.Extra.Test;

public class IsuExtraServiceTest
{
    [Fact]
    public void AddStudentOgnpGroup()
    {
        var isuExtraService = new IsuExtraServices();
        Group group = isuExtraService.AddGroup(new GroupName("М3213"));

            // Student student = isuExtraService.AddStudent(group, "Филиппова Виктория");
        MegaFaculty megaFaculty = isuExtraService.AddMegaFaculty("ТИнТ");
        OGNP ognp = isuExtraService.AddOGNP("Основы кибербезопасности", megaFaculty, 21);
        Flow flow = isuExtraService.AddFlow(3, ognp);
        OgnpGroup ognpGroup = isuExtraService.AddOgnpGroup(new OgnpGroupName("КИБ 3.1"), flow);
        StudentOgnpGroup studentOgnpGroup = ognpGroup.AddStudentOgnpGroup(new Student("Филиппова Виктория", 1, group));
        isuExtraService.AddStudentOgnpGroup(new Student("Филиппова Виктория", 1, group), ognpGroup);
        Assert.True(studentOgnpGroup.OgnpGroup.OgnpGroupName == ognpGroup.OgnpGroupName);
        Assert.Equal(ognpGroup, studentOgnpGroup.OgnpGroup);
        Assert.Equal(studentOgnpGroup.OgnpGroup, ognpGroup);
    }

    [Fact]
    public void CrossingLessons()
     {
         var isuExtraService = new IsuExtraServices();
         Group group = isuExtraService.AddGroup(new GroupName("М3213"));
         MegaFaculty megaFaculty = isuExtraService.AddMegaFaculty("ТИнТ");
         OGNP ognp = isuExtraService.AddOGNP("Основы кибербезопасности", megaFaculty, 21);
         Flow flow = isuExtraService.AddFlow(3, ognp);
         OgnpGroup ognpGroup = isuExtraService.AddOgnpGroup(new OgnpGroupName("КИБ 3.1"), flow);
         Lesson lesson = isuExtraService.AddLesson("Теория Вероятности", new DateTime(2022, 12, 1, 11, 00, 00), new DateTime(2022, 12, 1, 12, 30, 00), new ClassRoom(111), new Teacher("Исаева"), group);
         TimeTable timeTable = isuExtraService.AddTimeTable(ognpGroup, new DateTime(2022, 12, 1, 11, 00, 00), new DateTime(2022, 12, 1, 12, 30, 00));
         Assert.Throws<TimeCrossingException>(() => isuExtraService.AddStudentOgnpGroup(new Student("Филиппова Виктория", 1, group), ognpGroup));
     }
}