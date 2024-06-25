using Banks.Entities;
using Banks.Models;

namespace Banks.Interfaces;

public abstract class BankClientAccount
{
    protected BankClientAccount(Client client, DateTime creationDate)
    {
        Client = client;
        Id = Guid.NewGuid();
        CreationDate = creationDate;
    }

    public Guid Id { get; }

    public decimal Cash { get; protected set; }
    public decimal AdditionalCash { get; protected set; }
    public DateTime CreationDate { get; }
    public int DaysCounter { get; protected set; }
    public Client Client { get; }

    internal void Add(decimal cash)
    {
        Cash += cash;
    }

    internal abstract void Withdraw(BankConfig config, decimal cash);

    internal abstract void Notify(BankConfig config);
}