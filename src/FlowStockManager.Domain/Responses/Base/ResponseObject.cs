namespace FlowStockManager.Domain.Responses.Base
{
    public class ResponseObject
    {
        public string? Message { get; private set; }
        public object? Value { get; private set; }
        public IEnumerable<object>? Values { get; private set; }
        public bool IsSuccess { get; private set; }

        public ResponseObject(object value, bool isSuccess)
        {
            Value = value;
            IsSuccess = isSuccess;
        }

        public ResponseObject(IEnumerable<object> values, bool isSuccess, string message)
        {
            Values = values;
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
