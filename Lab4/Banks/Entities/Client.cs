using Banks.Exceptions;
using Banks.Interfaces;

namespace Banks.Entities;

public class Client : InfoListener
{
    public Client(string name, string surname)
    {
        if (name is null && surname is null)
        {
            throw new ClientException();
        }

        Name = name;
        Surname = surname;
    }

    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Address { get; private set; }
    public int PassportNumber { get; private set; }
    public int Inn { get; private set; }

    public Guid Id { get; } = Guid.NewGuid();

    public bool IsClientValid => Address is not null && PassportNumber != 0 && Inn != 0;

    public Client AddAddress(string address)
    {
        if (address is null)
        {
            throw new ClientException();
        }

        Address = address;
        return this;
    }

    public Client AddPassport(int passportNumber)
    {
        if (passportNumber == 0)
        {
            throw new ClientException();
        }

        PassportNumber = passportNumber;
        return this;
    }

    public Client AddInn(int inn)
    {
        if (inn == 0)
        {
            throw new ClientBuilderException();
        }

        Inn = inn;
        return this;
    }
}