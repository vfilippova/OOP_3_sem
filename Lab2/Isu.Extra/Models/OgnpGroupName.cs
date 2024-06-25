using Isu.Extra.Entites;
using Isu.Extra.Exception;

namespace Isu.Extra.Models;

public class OgnpGroupName
{
    public OgnpGroupName(string ognpGroupName)
    {
        CheckOgnpGroupName(ognpGroupName);
        Name = ognpGroupName;
        FlowNumber = Convert.ToInt32(ognpGroupName[3]);
        OgnpGroupNumber = Convert.ToInt32(ognpGroupName[5]);
    }

    public string Name { get; }
    public int FlowNumber { get; }
    public int OgnpGroupNumber { get; }

    public void CheckOgnpGroupName(string ognpGroupName)
    {
        // if (ognpGroupName.Length != 7)
        // {
        //     throw new InvalidOgnpGroupException(ognpGroupName);
        // }
        if (Convert.ToInt32(ognpGroupName[3]) < 1 && Convert.ToInt32(ognpGroupName[3]) > 4)
        {
            throw new InvalidOgnpGroupException(ognpGroupName);
        }
    }
}