namespace HeroManagement.Domain.Aggregates.Exceptions;

public class ArgumentNullValueException(string paramName)
    : ArgumentNullException(paramName, $"Argument \"{paramName}\" value is null");