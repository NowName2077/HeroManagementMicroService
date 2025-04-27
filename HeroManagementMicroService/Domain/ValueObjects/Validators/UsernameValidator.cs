using HeroManagementMicroService.Domain.ValueObjects.Exceptions;
using HeroManagementMicroService.Domain.ValueObjects.Base;

namespace HeroManagementMicroService.Domain.ValueObjects.Validators;
public class UsernameValidator : IValidator<string>
{
    public static int MAX_LENGTH => 30;
    public static int MIN_LENGTH => 3;

    public void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullOrWhiteSpaceException(ExceptionMessages.USERNAME_NOT_NULL_OR_WRITE_SPACES,
                nameof(value));
        if (value.Length > MAX_LENGTH)
            throw new UsernameLongValueException(value, MAX_LENGTH);
    }
}