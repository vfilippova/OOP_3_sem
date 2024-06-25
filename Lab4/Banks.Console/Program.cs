using Banks.Console.AccountHandler;
using Banks.Console.BankHandler;
using Banks.Console.TimeHandler;
using Banks.Exceptions;
using Banks.Facades;
using Banks.TimeTool;

var centralBank = new CentralBank();
var accountHandler = new AccountHandler(centralBank);
var bankHandler = new BankHandler(centralBank);
var timeHandler = new TimeHandler(new TimeProvider(centralBank));

Console.WriteLine("Выберите обработчик который вам требуется: \nБанк (bank) \nАккаунт (acc) \nВремя (time)");
while (true)
{
    try
    {
        string? cmd = Console.ReadLine();
        if (cmd != "acc" && cmd != "bank" && cmd != "time")
        {
            throw new InvalidCommand();
        }

        switch (cmd)
        {
            case "bank":
                bankHandler.Handle();
                break;
            case "acc":
                accountHandler.Handle();
                break;
            case "time":
                timeHandler.Handle();
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}