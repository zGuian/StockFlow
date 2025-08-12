using System.Net;

namespace FlowStockManager.Domain.Exceptions
{
    public sealed class FailureRegisterDataBaseException(string message) : StockFlowException(string.Empty)
    {        
        public override string GetErrorMessage() => message;

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
