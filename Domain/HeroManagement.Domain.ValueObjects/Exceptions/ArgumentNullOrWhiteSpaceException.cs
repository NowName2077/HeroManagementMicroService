namespace HeroManagement.Domain.ValueObjects.Exceptions;

public class ArgumentNullOrWhiteSpaceException(string paramName, string message)
    : ArgumentNullException(paramName, message);