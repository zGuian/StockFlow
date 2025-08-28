namespace FlowStockManager.Application.Commons.Interface
{
    public interface ICommandBase<TRequest, UResponse>
    {
        Task<UResponse> ExecuteAsync(TRequest request);
    }
}
