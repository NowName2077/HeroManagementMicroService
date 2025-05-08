using HeroManagement.Domain.ValueObjects.Base;
using HeroManagement.Domain.ValueObjects.Exceptions;

namespace HeroManagement.Domain.ValueObjects.Validators;

public class ObjectNameValidator : IValidator<string>
{
    public static int MIN_LENGTH = 3;
    public static int MAX_LENGTH = 30;

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value),
                ExceptionMessages.OBJECTNAME_NOT_NULL_OR_WRITE_SPACES);
        
        if (value.Length > MAX_LENGTH)
            throw new ObjectLongValueException(value, MAX_LENGTH);
        if (value.Length < MIN_LENGTH)
            throw new ObjectShortValueException(value, MIN_LENGTH);
    }
}