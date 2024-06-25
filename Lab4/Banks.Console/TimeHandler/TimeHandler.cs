using Banks.Exceptions;
using Banks.Facades;
using Banks.TimeTool;

namespace Banks.Console.TimeHandler;

public class TimeHandler : IHandler
{
    public TimeHandler(TimeProvider timeProvider)
    {
        TimeProvider = timeProvider;
    }

    public TimeProvider TimeProvider { get;  }

    public void Handle()
    {
        System.Console.WriteLine("Для перемещения во времени наберите: add\nчтобы узнать какой день сейчас: now");

        string? cmd = System.Console.ReadLine();
        if (cmd != "add" && cmd != "now")
        {
            throw new InvalidCommand();
        }

        switch (cmd)
        {
            case "add":
                System.Console.WriteLine("Введите кол-во дней для добавления:");
                TimeProvider.AddDays(Convert.ToInt32(System.Console.ReadLine()));
                break;
            case "now":
                System.Console.WriteLine(TimeProvider.DateTime);
                break;
        }
    }
}