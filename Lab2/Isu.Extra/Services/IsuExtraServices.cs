using Isu.Entities;
using Isu.Exception;
using Isu.Extra.Entites;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Models;
using Isu.Services;

namespace Isu.Extra.Services;
using Isu.Services;

public class IsuExtraServices : IsuService
{
    private List<StudentOgnpGroup> _studentsOgnpGroup = new List<StudentOgnpGroup>();
    private List<OGNP> _ognp = new List<OGNP>();
    private List<Flow> _flows = new List<Flow>();
    private List<TimeTable> _timeTables = new List<TimeTable>();
    private List<Lesson> _lessons = new List<Lesson>();
    private List<MegaFaculty> _megaFaculties = new List<MegaFaculty>();
    private List<OgnpGroup> _ognpGroups = new List<OgnpGroup>();

    public OGNP AddOGNP(string name, MegaFaculty megaFaculty, int maxStudent)
    {
        if (megaFaculty is null)
        {
            throw new System.Exception();
        }

        if (maxStudent <= 0)
        {
            throw new NegativeStudentInGroupOGNPException(maxStudent);
        }

        OGNP newOGNP = new OGNP(name, megaFaculty, maxStudent);
        _ognp.Add(newOGNP);
        return newOGNP;
    }

    public OgnpGroup AddOgnpGroup(OgnpGroupName ognpGroupName, Flow flow)
    {
        OgnpGroup newOgnpGroup = new OgnpGroup(ognpGroupName, flow);
        _ognpGroups.Add(newOgnpGroup);
        return newOgnpGroup;
    }

    public MegaFaculty AddMegaFaculty(string name)
    {
        MegaFaculty newMegaFaculty = new MegaFaculty(name);
        _megaFaculties.Add(newMegaFaculty);
        return newMegaFaculty;
    }

    public TimeTable AddTimeTable(OgnpGroup ognpGroup, DateTime startOGNP, DateTime endOGNP)
    {
        if (ognpGroup is null)
        {
            throw new System.Exception();
        }

        TimeTable newTimeTable = new TimeTable(ognpGroup, startOGNP, endOGNP);
        _timeTables.Add(newTimeTable);
        return newTimeTable;
    }

    public Lesson AddLesson(string name, DateTime startLesson, DateTime endLesson, ClassRoom classRoom, Teacher teacher, Group group)
    {
        if (classRoom is null)
        {
            throw new System.Exception();
        }

        if (teacher is null)
        {
            throw new System.Exception();
        }

        if (group is null)
        {
            throw new System.Exception();
        }

        Lesson newLesson = new Lesson(name, startLesson, endLesson, classRoom, teacher, group);
        _lessons.Add(newLesson);
        return newLesson;
    }

    public Flow AddFlow(int number, OGNP ognp)
    {
        if (ognp is null)
        {
            throw new System.Exception();
        }

        Flow newFlow = new Flow(number, ognp);
        _flows.Add(newFlow);
        return newFlow;
    }

    public StudentOgnpGroup AddStudentOgnpGroup(Student student, OgnpGroup ognpGroup)
    {
        int count = _studentsOgnpGroup.FindAll(studentOnGroup => studentOnGroup.OgnpGroup.Flow.OGNP == ognpGroup.Flow.OGNP).Count;
        int maxStudent = ognpGroup.Flow.OGNP.MaxStudent;
        if (count + 1 > maxStudent)
        {
            throw new MaxStudentInOGNPException(ognpGroup.Flow.OGNP.Name);
        }

        if (student is null)
        {
            throw new System.Exception();
        }

        if (ognpGroup is null)
        {
            throw new System.Exception();
        }

        List<TimeTable> timeTables = _timeTables.FindAll(timeTable => timeTable.OgnpGroup == ognpGroup);
        List<Lesson> lessons = _lessons.FindAll(lesson => lesson.Group == student.Group);
        foreach (TimeTable timeTable in timeTables)
        {
            if (!lessons.FindAll(lesson => lesson.StartLesson.Date == timeTable.StartOGNP.Date).All(lesson =>
                    lesson.StartLesson < timeTable.StartOGNP && lesson.EndLesson > timeTable.EndOGNP))
            {
                throw new TimeCrossingException(ognpGroup);
            }
        }

        StudentOgnpGroup newStudent = ognpGroup.AddStudentOgnpGroup(student);
        _studentsOgnpGroup.Add(newStudent);
        return newStudent;
    }

    public void RemoveStudentFromGroup(OgnpGroup ognpGroup, Student student)
    {
        if (ognpGroup is null)
        {
            throw new System.Exception();
        }

        if (student is null)
        {
            throw new System.Exception();
        }

        ognpGroup.RemoveStudent(student);
    }

    public List<Flow> GetFlowsByOGNP(OGNP ognp)
    {
        if (ognp is null)
        {
            throw new System.Exception();
        }

        List<Flow> flows = _flows.FindAll(flow => flow.OGNP == ognp);
        return flows;
    }

    public List<Student> GetStudentsByOgnpGroup(OgnpGroup ognpGroup)
    {
        if (ognpGroup is null)
        {
            throw new System.Exception();
        }

        List<Student> students =
            _studentsOgnpGroup.FindAll(studentsOgnpGroup => studentsOgnpGroup.OgnpGroup == ognpGroup).Select(student1 => student1.Student).ToList();
        return students;
    }

    public List<Student> NotFoundStudents(Group group)
    {
        if (group is null)
        {
            throw new System.Exception();
        }

        List<Student> students = FindStudents(group.GroupName).FindAll(s => !_studentsOgnpGroup.Select(s1 => s1.Student).Contains(s));
        return students;
    }
}