namespace FlowStockManager.Domain.Requests.UserRequests
{
    public class UpdateUserRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string UserKey { get; init; }
    }
}
