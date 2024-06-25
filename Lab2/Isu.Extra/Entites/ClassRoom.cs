using System.Diagnostics;

namespace Isu.Extra.Entites;

public class ClassRoom
{
    public ClassRoom(int name)
    {
        Name = name;
    }

    public int Name { get; set; }
}