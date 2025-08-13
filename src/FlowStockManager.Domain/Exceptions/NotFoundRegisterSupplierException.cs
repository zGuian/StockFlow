using System.Net;

namespace FlowStockManager.Domain.Exceptions
{
    public class NotFoundRegisterSupplierException(string message) : StockFlowException(string.Empty)
    {
        public override string GetErrorMessage() => $"ERRO AO BUSCAR FORNECEDOR CADASTRADO: {message}";

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
    }
}
