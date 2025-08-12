using System.Net;

namespace FlowStockManager.Domain.Exceptions
{
    public class BadRequestExceptions(string message) : StockFlowException(message)
    {
        private readonly string _message = message;

        public override string GetErrorMessage() => _message;

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
