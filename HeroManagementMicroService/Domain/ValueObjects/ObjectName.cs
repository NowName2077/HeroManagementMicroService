using HeroManagementMicroService.Domain.ValueObjects.Base;
using HeroManagementMicroService.Domain.ValueObjects.Validators;

namespace HeroManagementMicroService.Domain.ValueObjects;

public class ObjectName(string objectName): ValueObject<string>(new ObjectNameValidator(), objectName)
{
    
}