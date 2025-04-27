using HeroManagementMicroService.Domain.ValueObjects.Base;
using HeroManagementMicroService.Domain.ValueObjects.Validators;

namespace HeroManagementMicroService.Domain.ValueObjects;

public class Username(string name) : ValueObject<string>(new UsernameValidator(), name);