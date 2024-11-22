using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Validations;

public class CheckMinimalStockQuantity : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var minimal = (int)value!;

        if (minimal >= 5)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return ValidationResult.Success;
    }
}