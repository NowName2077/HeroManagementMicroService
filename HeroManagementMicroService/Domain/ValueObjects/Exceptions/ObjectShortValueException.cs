namespace HeroManagementMicroService.Domain.ValueObjects.Exceptions;

public class ObjectShortValueException(string subject, int minLength ): FormatException($"Title length {subject} shorter than minimum allowed length {minLength}")
{
    public string Subject => subject;
    public int MinLength => minLength;
}