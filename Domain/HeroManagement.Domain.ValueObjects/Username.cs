using HeroManagement.Domain.ValueObjects.Base;
using HeroManagement.Domain.ValueObjects.Validators;

namespace HeroManagement.Domain.ValueObjects;

public class Username(string name) : ValueObject<string>(new UsernameValidator(), name);
