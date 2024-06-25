namespace Isu.Extra.Entites;

public class Teacher
{
    public Teacher(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException();
        }

        Name = name;
    }

    public string Name { get; set; }
}
