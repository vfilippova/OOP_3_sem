using Banks.Entities;
using Banks.Exceptions;

namespace Banks.Builders;

public class ClientBuilder
{
    private string _name = null;
    private string _surname = null;
    private string _address = null;
    private int _passport = 0;
    private int _inn = 0;

    public ClientBuilder()
    {
    }

    public ClientBuilder AddName(string name)
    {
        if (name is null)
        {
            throw new ClientBuilderException();
        }

        _name = name;
        return this;
    }

    public ClientBuilder AddSurname(string surname)
    {
        if (surname is null)
        {
            throw new ClientBuilderException();
        }

        _surname = surname;
        return this;
    }

    public ClientBuilder AddAddress(string address)
    {
        if (address is null)
        {
            throw new ClientBuilderException();
        }

        _address = address;
        return this;
    }

    public ClientBuilder AddPassport(int passport)
    {
        if (passport is 0)
        {
            throw new ClientBuilderException();
        }

        _passport = passport;
        return this;
    }

    public ClientBuilder AddInn(int inn)
    {
        if (inn == 0)
        {
            throw new ClientBuilderException();
        }

        _inn = inn;
        return this;
    }

    public Client Build()
    {
        Client client = new Client(_name, _surname);
        client.AddAddress(_address);
        client.AddPassport(_passport);
        client.AddInn(_inn);
        return client;
    }
}