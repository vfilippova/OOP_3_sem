using System.Diagnostics;
using Isu.Exception;
using Isu.Models;
namespace Isu.Extra.Entites;

public class MegaFaculty
{
    public MegaFaculty(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException();
        }

        Name = name;
    }

    public string Name { get; set; }
}