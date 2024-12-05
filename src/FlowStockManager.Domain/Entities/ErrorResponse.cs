namespace FlowStockManager.Domain.Entities
{
    public class ErrorResponse : Exception
    {
        public int StatusCode { get; set; }
        public string MessageError { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        public ErrorResponse(string message) : base(message)
        {
            MessageError = message.ToUpper();
        }
    }
}
