using Contracts.Communication.Errors.Responses;
using Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FinancesException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var financesException = (FinancesException)context.Exception;
        var errorResponse = new ResponseErrorJson(financesException.GetErrors());

        context.HttpContext.Response.StatusCode = financesException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }
    
    private void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("Unknown error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}