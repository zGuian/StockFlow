using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Validations;

public class CheckPrice : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var price = (decimal)value;

        if (price < 0)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return ValidationResult.Success;
    }
}