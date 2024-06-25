using Banks.Facades;

namespace Banks.TimeTool;

public class TimeProvider
{
    private readonly CentralBank _centralBank;

    public TimeProvider(CentralBank centralBank)
    {
        _centralBank = centralBank;
    }

    public DateTime DateTime { get; private set; }

    public void AddDays(int days)
    {
        for (int i = 1; i <= days; i++)
        {
            _centralBank.Notify();
            DateTime += new TimeSpan(1, 0, 0, 0);
        }
    }
}