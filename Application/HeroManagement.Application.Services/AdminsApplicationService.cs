using HeroManagement.Application.Models.Admin;
using HeroManagement.Application.Services.Abstractions;
using HeroManagement.Domain.Abstractions;
using HeroManagement.Domain.ValueObjects;
using HeroManagement.Domain.Aggregates.Entities;
using AutoMapper;

namespace HeroManagement.Application.Services;

public class AdminsApplicationService(IAdminsRepository repository, IMapper mapper) : IAdminApplicationService
{
    public async Task<IEnumerable<AdminModel>> GetAdminsAsync(CancellationToken cancellationToken = default) 
        => (await repository.GetAllAsync(cancellationToken = default, true)).Select(mapper.Map<AdminModel>);

    public async Task<AdminModel?> GetAdminByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var admin = await repository.GetByIdAsync(id, cancellationToken);
        return admin is null ? null : mapper.Map<AdminModel>(admin);
    }

    public async Task<AdminModel?> GetAdminByUsernameAsync(string username,
        CancellationToken cancellationToken = default)
    {
        var admin = await repository.GetAdminByUsernameAsync(username, cancellationToken);
        return admin is null ? null : mapper.Map<AdminModel>(admin);
    }

    public async Task<AdminModel?> CreatAdminAsync(AdminCreateModel adminInformation,
        CancellationToken cancellationToken = default)
    {
        if (await repository.GetByIdAsync(adminInformation.Id, cancellationToken) is not null)
            return null;

        Admin admin = new(adminInformation.Id, new Username(adminInformation.Username));
        var createdAdmin = await repository.AddAsync(admin, cancellationToken);
        return createdAdmin is null ? null : mapper.Map<AdminModel>(createdAdmin);
    }

    public async Task<bool> UpdateAdminAsync(AdminModel admin, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(admin.Id, cancellationToken);
        if (entity is null) return false;
        
        entity = mapper.Map(admin, entity);
        return await repository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAdminAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var player = await repository.GetByIdAsync(id, cancellationToken);
        return player is null ? false : await repository.DeleteAsync(player, cancellationToken);
    }
    
}