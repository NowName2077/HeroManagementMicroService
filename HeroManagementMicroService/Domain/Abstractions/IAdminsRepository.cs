using HeroManagementMicroService.Domain.Aggregates.Entities;
namespace HeroManagementMicroService.Domain.Abstractions;

public interface IAdminsRepository: IRepository<Admin, Guid>
{
    Task<Admin?> GetAdminByUsernameAsync(string username, CancellationToken cancellationToken);
}