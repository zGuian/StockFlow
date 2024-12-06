using FlowStockManager.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace FlowStockManager.WebApi.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex);
            }
        }

        private static Task HandlerExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string stackTrace = string.Empty;
            string message;
            var exceptionType = ex.GetType();

            switch (exceptionType)
            {
                case Type _ when exceptionType == typeof(NullReferenceException):
                    message = ex.Message;
                    status = HttpStatusCode.NotFound;
                    stackTrace = ex.StackTrace!;
                    break;

                case Type _ when exceptionType == typeof(NotFoundExceptions):
                    message = ex.Message;
                    status = HttpStatusCode.NotFound;
                    stackTrace = ex.StackTrace!;
                    break;

                case Type _ when exceptionType == typeof(HttpRequestException):
                    message = ex.Message;
                    status = HttpStatusCode.BadRequest;
                    stackTrace = ex.StackTrace!;
                    break;

                case Type _ when exceptionType == typeof(BadRequestExceptions):
                    message = ex.Message;
                    status = HttpStatusCode.BadRequest;
                    stackTrace = ex.StackTrace!;
                    break;

                case Type _ when exceptionType == typeof(DbUpdateException):
                    message = ex.Message;
                    status = HttpStatusCode.BadRequest;
                    stackTrace = ex.StackTrace!;
                    break;

                case Type _ when exceptionType == typeof(NotSupportedException):
                    message = ex.Message;
                    status = HttpStatusCode.InternalServerError;
                    stackTrace = ex.StackTrace!;
                    break;

                case Type _ when exceptionType == typeof(Exception):
                    message = ex.Message;
                    status = HttpStatusCode.NotFound;
                    stackTrace = ex.StackTrace!;
                    break;

                default:
                    message = ex.Message;
                    status = HttpStatusCode.InternalServerError;
                    stackTrace = ex.StackTrace!;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { status, message, stackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }

    }
}
