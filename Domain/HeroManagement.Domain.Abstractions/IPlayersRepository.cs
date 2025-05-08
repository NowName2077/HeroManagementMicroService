using HeroManagement.Domain.Aggregates.Entities;

namespace HeroManagement.Domain.Abstractions;

public interface  IPlayersRepository : IRepository<Player, Guid>
{
    Task<Player?> GetPlayerByUsernameAsync(string username, CancellationToken cancellationToken);
}