namespace Reports.BLL.Exceptions;

public class ReportsException : Exception
{
    public ReportsException()
    {
    }

    public ReportsException(string message) : base(message)
    {
    }
}