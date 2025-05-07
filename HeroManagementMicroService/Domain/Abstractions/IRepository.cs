﻿using HeroManagementMicroService.Domain.Aggregates.Entities.Base;
namespace HeroManagementMicroService.Domain.Abstractions;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken);
}