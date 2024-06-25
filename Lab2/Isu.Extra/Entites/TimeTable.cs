namespace Isu.Extra.Entites;

public class TimeTable
{
    public TimeTable(OgnpGroup ognpGroup, DateTime startOGNP, DateTime endOGNP)
    {
        OgnpGroup = ognpGroup;
        StartOGNP = startOGNP;
        EndOGNP = endOGNP;
    }

    public OgnpGroup OgnpGroup { get; set; }
    public DateTime StartOGNP { get; set; }
    public DateTime EndOGNP { get; set; }
}