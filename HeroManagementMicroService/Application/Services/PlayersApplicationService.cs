using HeroManagementMicroService.Application.Models.Player;
using HeroManagementMicroService.Application.Services.Abstractions;
using HeroManagementMicroService.Domain.Abstractions;
using HeroManagementMicroService.Domain.ValueObjects;
using HeroManagementMicroService.Domain.Aggregates.Entities;
using AutoMapper;

namespace HeroManagementMicroService.Application.Services;

public class PlayersApplicationService(IPlayersRepository repository, IMapper mapper) : IPlayersApplicationService
{
    public async Task<IEnumerable<PlayerModel>> GetPlayersAsync(CancellationToken cancellationToken = default) 
        => (await repository.GetAllAsync(cancellationToken = default, true)).Select(mapper.Map<PlayerModel>);

    public async Task<PlayerModel?> GetPlayerByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var player = await repository.GetByIdAsync(id, cancellationToken);
        return player is null ? null : mapper.Map<PlayerModel>(player);
    }

    public async Task<PlayerModel?> GetPlayerByUsernameAsync(string username,
        CancellationToken cancellationToken = default)
    {
        var player = await repository.GetPlayerByUsernameAsync(username, cancellationToken);
        return player is null ? null : mapper.Map<PlayerModel>(player);
    }

    public async Task<PlayerModel?> CreatPlayerAsync(PlayerCreateModel playerInformation,
        CancellationToken cancellationToken = default)
    {
        if (await repository.GetByIdAsync(playerInformation.Id, cancellationToken) is not null)
            return null;

        Player player = new(playerInformation.Id, new Username(playerInformation.Username));
        var createdPlayer = await repository.AddAsync(player, cancellationToken);
        return createdPlayer is null ? null : mapper.Map<PlayerModel>(createdPlayer);
    }

    public async Task<bool> UpdatePlayerAsync(PlayerModel player, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(player.Id, cancellationToken);
        if (entity is null) return false;
        
        entity = mapper.Map(player, entity);
        return await repository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeletePlayerAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var player = await repository.GetByIdAsync(id, cancellationToken);
        return player is null ? false : await repository.DeleteAsync(player, cancellationToken);
    }
}


//     public async Task<IEnumerable<PlayerModel>> GetPlayersAsync(CancellationToken cancellationToken = default) 
//         => (await repository.GetAllAsync(cancellationToken = default, true)).Select(mapper.Map<PlayerModel>);
//
//     public async Task<PlayerModel?> GetPlayerByIdAsync(Guid id, CancellationToken cancellationToken = default)
//     {
//         var player = await repository.GetByIdAsync(id, cancellationToken);
//         return player is null ? null : mapper.Map<PlayerModel>(player);
//     }
//
//     public async Task<PlayerModel?> GetPlayerByUsernameAsync(string username, CancellationToken cancellationToken = default)
//     {
//         var player = await repository.GetPlayerByUsernameAsync(username, cancellationToken);
//         return player is null ? null : mapper.Map<PlayerModel>(player);
//     }
//
//     public async Task<PlayerModel?> CreatePlayerAsync(PlayerCreateModel playerInformation, CancellationToken cancellationToken = default)
//     {
//         if (await repository.GetByIdAsync(playerInformation.Id, cancellationToken) is not null)
//             return null;
//         Player player = new(playerInformation.Id, new Username(playerInformation.Username));
//         var createdPlayer = await repository.AddAsync(player, cancellationToken);
//         return createdPlayer is null ? null : mapper.Map<PlayerModel>(createdPlayer);
//     }
//
//     public async Task<bool> UpdatePlayerAsync(PlayerModel player, CancellationToken cancellationToken = default)
//     {
//         var entity = await repository.GetByIdAsync(player.Id, cancellationToken);
//         if (entity is null) return false;
//         entity = mapper.Map<Player>(player);
//         return await repository.UpdateAsync(entity, cancellationToken);
//     }
//
//     public async Task<bool> DeletePlayerAsync(Guid id, CancellationToken cancellationToken = default)
//     {
//         var player = await repository.GetByIdAsync(id, cancellationToken);
//         return player is null ? false : await repository.DeleteAsync(player, cancellationToken);
//     }
// }