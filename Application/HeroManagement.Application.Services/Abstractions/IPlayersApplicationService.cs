using HeroManagement.Application.Models.Player;

namespace HeroManagement.Application.Services.Abstractions;

public interface IPlayersApplicationService
{
    Task<PlayerModel?> GetPlayerByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PlayerModel?> GetPlayerByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<IEnumerable<PlayerModel>> GetPlayersAsync(CancellationToken cancellationToken);
    Task<PlayerModel?> CreatPlayerAsync(PlayerCreateModel playerInformation, CancellationToken cancellationToken);
    Task<bool> UpdatePlayerAsync(PlayerModel player, CancellationToken cancellationToken);
    Task<bool> DeletePlayerAsync(Guid id, CancellationToken cancellationToken);
}