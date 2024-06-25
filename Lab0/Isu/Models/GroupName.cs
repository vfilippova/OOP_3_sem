using Isu.Exception;

namespace Isu.Models;

public class GroupName
{
    public GroupName(string groupName)
    {
        CheckGroupName(groupName);
        Name = groupName;
        Degree = groupName[1];
        CourseNumber = new CourseNumber(Convert.ToInt32(groupName[2]));
        GroupNumber = Convert.ToInt32(groupName.Substring(3, 2));
    }

    public string Name { get; }
    public int Degree { get; }
    public CourseNumber CourseNumber { get; }
    public int GroupNumber { get; }

    public void CheckGroupName(string groupName)
    {
        if (groupName.Length != 5)
        {
            throw new InvalidGroupException(groupName);
        }

        if (groupName[1] != '3')
        {
            throw new InvalidGroupException(groupName);
        }

        if (Convert.ToInt32(groupName[2]) < 1 && Convert.ToInt32(groupName[2]) > 4)
        {
            throw new InvalidGroupException(groupName);
        }
    }
}