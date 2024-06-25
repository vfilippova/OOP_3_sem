using Banks.Entities;
using Banks.Exceptions;
using Banks.Facades;
using Banks.Interfaces;

namespace Banks.Console.AccountHandler;

public class AccountHandler : IHandler
{
    public AccountHandler(CentralBank centralBank)
    {
        CentralBank = centralBank;
    }

    public CentralBank CentralBank { get; }

    public void Handle()
    {
        System.Console.WriteLine("Создать клиента: create \nId аккаунтов: all \nСнять деньги: withdraw \nПоложить деньги: put \nПеревести деньги: transfer \nПроверить баланс: balance");
        string? cmd = System.Console.ReadLine();
        if (cmd != "create" && cmd != "all" && cmd != "withdraw" && cmd != "put" && cmd != "transfer" && cmd != "balance")
        {
            throw new InvalidCommand();
        }

        switch (cmd)
        {
            case "create":
                System.Console.WriteLine("Введите: bank id, client id and type of account");
                Bank bank = CentralBank.GetBank(Guid.Parse(System.Console.ReadLine() ??
                                                           throw new InvalidOperationException()));
                Client client =
                    CentralBank.GetClient(
                        Guid.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException()));
                AccountType accountType = System.Console.ReadLine()
                    switch
                {
                    "credit" => AccountType.Credit,
                    "debit" => AccountType.Debit,
                    "deposit" => AccountType.Deposit,
                    _ => AccountType.Debit
                };

                bank.CreateAccount(client, accountType, DateTime.Now);
                break;
            case "all":
                int c = 0;
                foreach (BankClientAccount account in CentralBank.Accounts)
                {
                    c++;
                    System.Console.WriteLine($"{c}. {account.Id}");
                }

                break;
            case "withdraw":
                System.Console.WriteLine("Введите: bank id, account и кол-во денег");
                Bank withdrawBank = CentralBank.GetBank(Guid.Parse(System.Console.ReadLine() ??
                                                                   throw new InvalidOperationException()));

                withdrawBank.WithdrawMoney(
                    CentralBank
                        .GetAccount(
                            Guid.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException())),
                    Convert.ToDecimal(System.Console.ReadLine()));
                break;
            case "put":
                System.Console.WriteLine("Введите: bank id, account и кол-во денег");
                Bank putBank = CentralBank.GetBank(Guid.Parse(System.Console.ReadLine() ??
                                                              throw new InvalidOperationException()));

                putBank.PutMoney(
                    CentralBank
                        .GetAccount(
                            Guid.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException())),
                    Convert.ToDecimal(System.Console.ReadLine()));
                break;
            case "transfer":
                System.Console.WriteLine("Введите: fromAccount id, toAccount id, кол-во денег");
                CentralBank.Transfer(
                    CentralBank
                        .GetAccount(
                            Guid.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException())),
                    CentralBank
                        .GetAccount(
                            Guid.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException())),
                    Convert.ToDecimal(System.Console.ReadLine()));
                break;

            case "balance":
                System.Console.WriteLine("Введите: acc id");
                BankClientAccount curAcc = CentralBank.GetAccount(Guid.Parse(System.Console.ReadLine() ??
                                                           throw new InvalidOperationException()));
                decimal cash = curAcc.Cash;
                System.Console.WriteLine(cash);
                break;
        }
    }
}