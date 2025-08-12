using System.Net;

namespace FlowStockManager.Domain.Exceptions
{
    public class NotFoundExceptions(string message) : StockFlowException(message)
    {
        private readonly string _message = message;

        public override string GetErrorMessage() => _message;

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
    }
}
