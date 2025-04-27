using HeroManagementMicroService.Domain.Aggregates.Entities;
namespace HeroManagementMicroService.Domain.Abstractions;

public interface IAdminRepository: IRepository<Admin, Guid>
{
    Task<Admin?> GetAdminByUsernameAsync(string username, CancellationToken cancellationToken);
}