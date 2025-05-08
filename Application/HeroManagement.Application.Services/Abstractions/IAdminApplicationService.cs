using HeroManagement.Application.Models.Admin;

namespace HeroManagement.Application.Services.Abstractions;

public interface IAdminApplicationService
{
    Task<AdminModel?> GetAdminByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<AdminModel?> GetAdminByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<IEnumerable<AdminModel>> GetAdminsAsync(CancellationToken cancellationToken);
    Task<AdminModel?> CreatAdminAsync(AdminCreateModel adminrInformation, CancellationToken cancellationToken);
    Task<bool> UpdateAdminAsync(AdminModel admin, CancellationToken cancellationToken);
    Task<bool> DeleteAdminAsync(Guid id, CancellationToken cancellationToken);
}
