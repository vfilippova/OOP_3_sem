using Banks.Builders;
using Banks.Entities;
using Banks.Exceptions;
using Banks.Facades;
using Banks.Models;

namespace Banks.Console.BankHandler;

public class BankHandler : IHandler
{
    public BankHandler(CentralBank centralBank)
    {
        CentralBank = centralBank;
    }

    private CentralBank CentralBank { get; }

    public void Handle()
    {
        System.Console.WriteLine("Cоздать банка: create \nId и список банков: all \nСоздать клиента: client \nID клиента: clients \nКонфигурация: config");
        string? cmd = System.Console.ReadLine();
        if (cmd != "create" && cmd != "all" && cmd != "client" && cmd != "clients" && cmd != "config")
        {
            throw new InvalidCommand();
        }

        switch (cmd)
        {
            case "create":
                System.Console.WriteLine("Введите имя банка:");
                CentralBank.AddBank(System.Console.ReadLine() ?? throw new InvalidOperationException());
                break;
            case "client":
                System.Console.WriteLine("Введите: name, surname, address, passport, inn, bank id");
                Client client1 = new Client(System.Console.ReadLine(), System.Console.ReadLine());
                client1.AddAddress(System.Console.ReadLine());
                client1.AddPassport(Convert.ToInt32(System.Console.ReadLine()));
                client1.AddInn(Convert.ToInt32(System.Console.ReadLine()));
                CentralBank.AddClient(client1);
                Bank bank1 = CentralBank.GetBank(Guid.Parse(System.Console.ReadLine() ??
                                                            throw new InvalidOperationException()));
                bank1.AddClient(client1);
                break;
            case "clients":
                foreach (Client client in CentralBank.Clients)
                {
                    System.Console.WriteLine($"{client.Name} {client.Surname}:   {client.Id}");
                }

                break;
            case "config":

                System.Console.WriteLine(
                    "Введите: bank id, credit percent, debit percent, limit for transactions");
                bank1 = CentralBank.GetBank(Guid.Parse(System.Console.ReadLine() ??
                                                       throw new InvalidOperationException()));
                decimal creditPercent = decimal.Parse(System.Console.ReadLine() ??
                                                      throw new InvalidOperationException());
                decimal debitPercent = decimal.Parse(System.Console.ReadLine() ??
                                                     throw new InvalidOperationException());
                decimal limit = decimal.Parse(System.Console.ReadLine() ??
                                              throw new InvalidOperationException());
                System.Console.WriteLine("Введите количество промежутков для депозитонго процента:");
                int n = int.Parse(System.Console.ReadLine() ??
                                  throw new InvalidOperationException());

                if (n <= 0)
                {
                    throw new Exception("Нужен хотя бы один промежуток");
                }

                var model = new DepositPercentModel();
                System.Console.WriteLine(
                    $"Введите процент и граничное значение (суммарно {(2 * n) - 1} чисел):");
                for (int i = 0; i < n - 1; i++)
                {
                    decimal sum = decimal.Parse(System.Console.ReadLine() ??
                                                throw new InvalidOperationException());
                    decimal percent = decimal.Parse(System.Console.ReadLine() ??
                                                    throw new InvalidOperationException());
                    model.Add(sum, percent);
                }

                decimal last = decimal.Parse(System.Console.ReadLine() ??
                                             throw new InvalidOperationException());
                model.Add(decimal.MaxValue, last);
                bank1.SetConfig(new BankConfig(creditPercent, debitPercent, model, limit));
                System.Console.WriteLine("Config created");
                break;
            case "all":
            {
                foreach (Bank bank in CentralBank.Banks)
                {
                    System.Console.WriteLine($"{bank.Name}:   {bank.Id}");
                }

                break;
            }
        }
    }
}