using FluentValidation.Results;

namespace Domain.Utils
{
    public static class ValidationResultExtension
    {
        public static void AddError(this ValidationResult validationResult, string message)
        {
            var valdationFailure = new ValidationFailure(null, message);
            validationResult.Errors.Add(valdationFailure);
        }
    }
}