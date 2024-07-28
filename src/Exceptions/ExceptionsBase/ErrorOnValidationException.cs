using System.Net;

namespace Exceptions.ExceptionsBase;

public class ErrorOnValidationException(List<string> errorsMessages) : FinancesException(string.Empty)
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors()
    {
        return errorsMessages;
    }
}