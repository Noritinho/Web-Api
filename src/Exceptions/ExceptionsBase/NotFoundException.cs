using System.Net;

namespace Exceptions.ExceptionsBase;

public class NotFoundException(string message, int statusCode) : FinancesException(message)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [message];
    }
}