using HeroManagementMicroService.Domain.Aggregates.Entities;
namespace HeroManagementMicroService.Domain.Abstractions;

// public interface IPlayerRepository: IRepository<Player, Guid>
// {
//     Task<Player?> GetPlayerByUsernameAsync(string username, CancellationToken cancellationToken);
// }

public interface IPlayerRepository : IRepository<Player, Guid>
{
    Task<Player?> GetPlayerByUsernameAsync(string username, CancellationToken cancellationToken);
}