using Isu.Entities;

namespace Isu.Extra.Entites;

public class OGNP
{
    public OGNP(string name, MegaFaculty megaFaculty, int maxStudent)
    {
        if (name == null)
        {
            throw new ArgumentNullException();
        }

        Name = name;
        MegaFaculty = megaFaculty;
        MaxStudent = maxStudent;
    }

    public string Name { get; set; }
    public MegaFaculty MegaFaculty { get;  }
    public int MaxStudent { get; }
}
