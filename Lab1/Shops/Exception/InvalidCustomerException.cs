namespace Shops.Exception;

public class InvalidCustomerException : SystemException
{
    public InvalidCustomerException(string customerName)
        : base($"Customer {customerName} does not exist")
    {
    }

    public InvalidCustomerException(int balance)
        : base($"Balanse {balance} ")
    {
    }
}