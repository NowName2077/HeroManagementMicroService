using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface IAdminsRepository : IRepository<Admin, Guid>
{
    Task<Admin?> GetAdminByUsernameAsync(string username, CancellationToken cancellationToken);
}