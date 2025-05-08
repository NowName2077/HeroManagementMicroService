using HeroManagement.Domain.ValueObjects.Base;
using HeroManagement.Domain.ValueObjects.Validators;

namespace HeroManagement.Domain.ValueObjects;

public class ObjectName(string objectName): ValueObject<string>(new ObjectNameValidator(), objectName);