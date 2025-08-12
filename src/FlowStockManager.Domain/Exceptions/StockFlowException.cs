using System.Net;

namespace FlowStockManager.Domain.Exceptions
{
    public abstract class StockFlowException(string message) : SystemException(message)
    {
        public abstract string GetErrorMessage();
        public abstract HttpStatusCode GetStatusCode();
    }
}
