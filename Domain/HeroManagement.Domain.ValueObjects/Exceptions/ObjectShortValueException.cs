namespace HeroManagement.Domain.ValueObjects.Exceptions;

public class ObjectShortValueException(string objectName, int minLength)
    : FormatException($"Title length {objectName} shorter than minimum allowed length {minLength}")
{
    public string ObjectName => objectName;
    public int MinLength => minLength;
}