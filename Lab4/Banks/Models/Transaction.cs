using Banks.Exceptions;
using Banks.Interfaces;

namespace Banks.Models;

public class Transaction
{
    public Transaction(decimal cash, BankConfig config)
    {
        Cash = cash;
        Config = config;
        if (Config == null)
        {
            throw new NullReferenceException();
        }
    }

    public decimal Cash { get; }
    public BankConfig Config { get; }
    public BankClientAccount Sender { get; private set; }
    public BankClientAccount Receiver { get; private set; }

    public void AddSender(BankClientAccount bankClientAccount)
    {
        Sender = bankClientAccount;
        if (Sender is null)
        {
            throw new TransactionException();
        }
    }

    public void AddReceiver(BankClientAccount bankClientAccount)
    {
        Receiver = bankClientAccount;
        if (Receiver is null)
        {
            throw new TransactionException();
        }
    }

    public void Undo()
    {
        Sender.Add(Cash);

        Receiver.Withdraw(Config, Cash);
    }
}