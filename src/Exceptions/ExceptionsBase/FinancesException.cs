namespace Exceptions.ExceptionsBase;

public abstract class FinancesException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}