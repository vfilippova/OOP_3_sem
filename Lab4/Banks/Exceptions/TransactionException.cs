namespace Banks.Exceptions;

public class TransactionException : SystemException
{
    public TransactionException()
        : base($"Transaction is nulll")
    {
    }
}