using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Requests.UserRequests
{
    public class CreateUserRequest
    {
        [Required]
        public required string FirstName { get; init; }

        [Required]
        public required string LastName { get; init; }

        [Required]
        public required string Email { get; init; }

        [Required, PasswordPropertyText(true)]
        public required string Password { get; init; }

        [Required, Compare(nameof(Password)), PasswordPropertyText(true)]
        public required string ConfirmPassword { get; init; }
    }
}
