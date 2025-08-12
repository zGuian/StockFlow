using FlowStockManager.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlowStockManager.WebApi.Filters
{
    public class ExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is StockFlowException stockFlowException)
                HandleProjectException(stockFlowException, context);
            else
                ThrowUnknowException(context);
        }

        private static void HandleProjectException(StockFlowException stockFlowException, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)stockFlowException.GetStatusCode();
            context.Result = new ObjectResult(new
            {
                Message = stockFlowException.GetErrorMessage(),
                stockFlowException.InnerException,
                stockFlowException.StackTrace
            });
        }

        private static void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new
            {
                context.Exception.Message,
                context.Exception.InnerException,
                context.Exception.StackTrace
            });
        }
    }
}
