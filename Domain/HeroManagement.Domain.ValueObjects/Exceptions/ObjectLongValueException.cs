namespace HeroManagement.Domain.ValueObjects.Exceptions;

public class ObjectLongValueException(string objectName, int maxLength)
    : FormatException($"Title length {objectName} greater than maximum allowed length {maxLength}")
{
    public string ObjectName => objectName;
    public int MaxLength => maxLength;
}