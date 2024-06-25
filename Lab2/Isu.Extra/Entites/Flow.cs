using Isu.Entities;

namespace Isu.Extra.Entites;

public class Flow
{
    public Flow(int number, OGNP ognp)
    {
        if (number <= 0)
        {
            throw new SystemException();
        }

        Number = number;
        OGNP = ognp;
    }

    public int Number { get; set; }
    public OGNP OGNP { get; set; }
}